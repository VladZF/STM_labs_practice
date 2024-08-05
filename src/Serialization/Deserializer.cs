using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serialization;

public static class Deserializer
{
    private static object? DeserializeHelper(JsonElement jsonElement, Type type)
    {
        if (jsonElement.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        var primitive = ParsePrimitive(jsonElement, type);
        if (primitive != null)
        {
            return primitive;
        }
        if (type.IsArray)
        {
            return DeserializeArray(jsonElement, type.GetElementType()!);
        }
        if (type.GetInterfaces().Contains(typeof(IDictionary)))
        {
            return DeserializeDictionary(jsonElement, type.GetGenericArguments());
        }
        if (type.GetInterfaces().Contains(typeof(IEnumerable)))
        {
            return DeserializeSequence(jsonElement, type.GetGenericArguments()[0]);
        }
        return type.IsEnum ? Enum.Parse(type, jsonElement.ToString()) : DeserializeClass(jsonElement, type);
    }
    
    private static object? DeserializeClass(JsonElement jsonElement, Type type)
    {
        var obj = Activator.CreateInstance(type);
        foreach (var property in type.GetProperties())
        {
            if (property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
            {
                continue;
            }
            var propertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;
            var jsonProperty = jsonElement.GetProperty(propertyName);
            property.SetValue(obj, DeserializeHelper(jsonProperty, property.PropertyType));
        }
        return obj;
    }
    
    private static object DeserializeArray(JsonElement jsonElement, Type elementType)
    {
        var array = Array.CreateInstance(elementType, jsonElement.GetArrayLength());
        var index = 0;
        foreach (var element in jsonElement.EnumerateArray())
        {
            array.SetValue(DeserializeHelper(element, elementType), index++);
        }

        return array;
    }
    
    private static object DeserializeSequence(JsonElement jsonElement, Type genericType)
    {
        var sequence = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(genericType))!;
        foreach (var element in jsonElement.EnumerateArray())
        {
            sequence.Add(DeserializeHelper(element, genericType));
        }

        return sequence;
    }
    
    private static object DeserializeDictionary(JsonElement jsonElement, Type[] genericTypes)
    {
        var dictionary = (IDictionary)Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(genericTypes))!;
        foreach (var property in jsonElement.EnumerateObject())
        {
            dictionary.Add(property.Name, DeserializeHelper(property.Value, genericTypes[1]));
        }

        return dictionary;
    }
    
    private static object? ParsePrimitive(JsonElement jsonElement, Type type)
    {
        if (type == typeof(bool))
        {
            return jsonElement.GetBoolean();
        }
        if (type == typeof(int))
        {
            return jsonElement.GetInt32();
        }
        if (type == typeof(float))
        {
            return jsonElement.GetSingle();
        }
        if (type == typeof(double))
        {
            return jsonElement.GetDouble();
        }
        if (type == typeof(decimal))
        {
            return jsonElement.GetDecimal();
        }
        if (type == typeof(string))
        {
            return jsonElement.GetString();
        }

        return null;
    }
    
    public static T? Deserialize<T>(string jsonString)
    {
        using var info = JsonDocument.Parse(jsonString);
        return (T?)DeserializeHelper(info.RootElement, typeof(T));
    }
}