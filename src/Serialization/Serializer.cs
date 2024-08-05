using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Serialization;

public static class Serializer
{
    private static string SerializeDictionary(IDictionary dictionary)
    {
        var converted = new StringBuilder("{");
        foreach (var key in dictionary.Keys)
        {
            converted.Append($"{Serialize(key)}: {Serialize(dictionary[key])},");
        }
        return converted.Length == 1
            ? converted.Append('}').ToString()
            : converted.Remove(converted.Length - 1, 1).Append('}').ToString();
    }
    private static string SerializeSequence(IEnumerable sequence)
    {
        var converted = new StringBuilder("[");
        foreach (var item in sequence)
        {
            converted.Append($"{Serialize(item)},");
        }
        
        return converted.Length == 1
            ? converted.Append(']').ToString()
            : converted.Remove(converted.Length - 1, 1).Append(']').ToString();
    }
    
    private static string SerializeClass(object? obj, Type type)
    {
        var converted = new StringBuilder("{");
        foreach (var property in type.GetProperties())
        {
            if (property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
            {
                continue;
            }
            var propertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name;
            converted.Append($"\"{propertyName}\": {Serialize(property.GetValue(obj))},");
        }
        return converted.Length == 1
            ? converted.Append('}').ToString()
            : converted.Remove(converted.Length - 1, 1).Append('}').ToString();
    }
    public static string? Serialize(object? obj)
    {
        if (obj == null)
        {
            return "null";
        }
        var type = obj.GetType();
        if (type == typeof(string))
        {
            return "\"" + obj + "\"";
        }
        if (type.IsPrimitive)
        {
            return obj.ToString();
        }
        if (type.IsEnum)
        {
            return "\"" + obj + "\"";
        }
        if (type.GetInterfaces().Contains(typeof(IDictionary)))
        {
            return SerializeDictionary((IDictionary)obj);
        }
        if (type.GetInterfaces().Contains(typeof(IEnumerable)))
        {
            return SerializeSequence((IEnumerable)obj);
        }
        
        return SerializeClass(obj, type);
    }
}