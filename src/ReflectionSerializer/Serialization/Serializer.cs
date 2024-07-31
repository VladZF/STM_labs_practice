using System.Collections;
using System.Text;

namespace ReflectionSerializer;

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
            converted.Append($"{property.Name}: {Serialize(property.GetValue(obj))},");
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
        if (type.IsPrimitive || type == typeof(string))
        {
            return obj.ToString();
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