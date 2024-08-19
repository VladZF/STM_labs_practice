namespace ThreadsConsole;

public class FileReader
{
    private readonly int _number;
    private Task _task;
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly int _delay;
    private readonly int _itemsPerIteration;
    private readonly string _path;
    
    public FileReader(string path, int delay, int itemsPerIteration, int number)
    {
        _number = number;
        _path = path;
        _itemsPerIteration = itemsPerIteration;
        _delay = delay;
    }

    private void ReadFile(StreamWriter writer, int number)
    {
        var streamReader = new StreamReader(_path);
        while (!streamReader.EndOfStream)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                writer.WriteLine($"Thread {number} aborted");
                writer.Flush();
                _tokenSource.Dispose();
                return;
            }
            for (var i = 0; i < _itemsPerIteration && !streamReader.EndOfStream; i++)
            {
                writer.WriteLine($"Thread {number}: " + streamReader.ReadLine());
                writer.Flush();
            }
            Thread.Sleep(_delay);
        }
        writer.WriteLine($"Thread {number} finished");
        writer.Flush();
    }
    
    public void StartReader(StreamWriter writer)
    {
        _task = Task.Run(() => ReadFile(writer, _number));
    }
    
    public void StopReader() => _tokenSource.Cancel();
}