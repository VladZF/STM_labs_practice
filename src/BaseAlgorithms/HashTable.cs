using System.Text;

namespace BaseAlgorithms;

public class HashTable
{
    private List<(string key, int value)>[] _values;
    
    public HashTable(int size)
    {
        _values = new List<(string key, int value)>[size];
        for (var i = 0; i < size; i++)
        {
            _values[i] = [];
        }
    }
    
    public HashTable() : this(10)
    {
    }
    
    public void Put(string key, int value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key is empty or null");
        }
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        for (var ptr = 0; ptr < _values[index].Count; ++ptr)
        {
            if (_values[index][ptr].key == key)
            {
                _values[index][ptr] = (key, value);
                return;
            }
        }
        _values[index].Add((key, value));
    }
    
    public int Get(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key is empty or null");
        }
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        var result = _values[index].FirstOrDefault(item => item.key == key);
        if (result == (null, 0))
        {
            throw new ArgumentException($"GET: Table does not has key '{key}'");
        }
        return result.value;
    }
    
    public void Delete(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key is empty or null");
        }
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        var result = _values[index].FirstOrDefault(item => item.key == key);
        if (result == (null, 0))
        {
            throw new ArgumentException($"DELETE: Table does not has key '{key}'");
        }
        _values[index].Remove(result);
    }

    public override string ToString()
    {
        var info = new StringBuilder();
        info.Append('{');
        foreach (var bucket in _values)
        {
            foreach (var item in bucket)
            {
                info.Append($"{item.key}: {item.value}, ");
            }
        }

        if (info.Length == 1)
        {
            return info.Append('}').ToString();
        }
        info.Remove(info.Length - 2, 2).Append('}');
        return info.ToString();
    }
}