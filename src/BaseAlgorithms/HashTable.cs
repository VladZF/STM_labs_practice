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
    
    public void Put(string key, int value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        for (var ptr = 0; ptr < _values[index].Count; ++ptr)
        {
            if (_values[index][ptr].key == key)
            {
                _values[index][ptr] = (key, value);
                Console.WriteLine($"ADD: Value with key '{key}' rewritten by value {value}");
                return;
            }
        }
        _values[index].Add((key, value));
        Console.WriteLine($"ADD: Added key '{key}' with value {value}");
    }
    
    public int Get(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        foreach (var item in _values[index].Where(item => item.key == key))
        {
            return item.value;
        }

        throw new ArgumentException($"GET: No key '{key}' in table");
    }
    
    public void Delete(string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        var index = Math.Abs(key.GetHashCode()) % _values.Length;
        foreach (var item in _values[index].Where(item => item.key == key))
        {
            _values[index].Remove(item);
            Console.WriteLine($"DELETE: Key '{item.key}' with value '{item.value}' removed from table");
            return;
        }
        Console.WriteLine($"DELETE: There is no key '{key}'");
    }
    
    public void Print()
    {
        Console.WriteLine("PRINT:");
        var counter = 1;
        foreach (var bucket in _values)
        {
            Console.Write(counter + ": ");
            foreach (var item in bucket)
            {
                Console.Write($"({item.key}: {item.value}) ");
            }
            Console.WriteLine();
            counter++;
        }
    }
}