namespace ThreadsConsole;

public class FileReader
{
    private Task _task;
    private readonly CancellationTokenSource _tokenSource = new();
    private readonly int _delay;
    private readonly int _itemsPerIteration;
    private readonly string _path;
    
    public FileReader(string path, int delay, int itemsPerIteration)
    {
        _path = path;
        _itemsPerIteration = itemsPerIteration;
        _delay = delay;
    }

    private void ReadFile(StreamWriter writer)
    {
        var streamReader = new StreamReader(_path);
        while (!streamReader.EndOfStream)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                break;
            }
            for (var i = 0; i < _itemsPerIteration && !streamReader.EndOfStream; i++)
            {
                writer.WriteLine(streamReader.ReadLine());
                writer.Flush();
            }
            Thread.Sleep(_delay);
        }
    }
    
    public void StartReader(StreamWriter writer)
    {
        _task = Task.Run(() => ReadFile(writer));
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