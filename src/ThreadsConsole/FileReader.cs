namespace ThreadsConsole;

public class FileReader
{
    private readonly int _number;
    private Task _task;
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly int _delay;
    private readonly int _itemsPerIteration;
    private readonly string _path;
    public bool IsFinished { get; private set; }
    
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
                break;
            }
            for (var i = 0; i < _itemsPerIteration && !streamReader.EndOfStream; i++)
            {
                writer.WriteLine($"Thread {number}: " + streamReader.ReadLine());
                writer.Flush();
            }
            Thread.Sleep(_delay);
        }
        IsFinished = true;
    }
    
    public void StartReader(StreamWriter writer)
    {
        _task = Task.Run(() => ReadFile(writer, _number));
    }
    
    public void StopReader()
    {
        _tokenSource.Cancel();
        try
        {
            _task.Wait();
        }
        catch (AggregateException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _tokenSource.Dispose();
        }
    }
}