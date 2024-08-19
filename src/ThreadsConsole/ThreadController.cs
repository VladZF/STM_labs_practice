using System.IO.Pipes;

namespace ThreadsConsole;

public class ThreadController(NamedPipeServerStream serverStream)
{
    private readonly List<FileReader> _readers = [];
    private StreamWriter _writer = new(serverStream);
    private NamedPipeServerStream _serverStream = serverStream;
    
    
    public void AddReaders(string path, int delay, int itemsPerIteration, int count)
    {
        for (var _ = 0; _ < count; _++)
        {
            var reader = new FileReader(path, delay, itemsPerIteration);
            _readers.Add(reader);
            reader.StartReader(_writer);
        }
    }
    public void RemoveLastReader()
    {
        _readers.Last().StopReader();
        _readers.RemoveAt(_readers.Count - 1);
        if (_readers.Count == 0)
        {
            _writer.Dispose();
        }
    }
    
    public void StopAllReaders()
    {
        while (_readers.Count != 0)
        {
            RemoveLastReader();
        }
        _writer.Dispose();
    }
}