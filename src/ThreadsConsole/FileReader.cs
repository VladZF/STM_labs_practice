namespace ThreadsConsole;

public class FileReader
{
    public Task Task { get; set; }
    public CancellationTokenSource TokenSource = new();
    private readonly int _delay;
    private readonly int _itemsPerIteration;
    private readonly string _path;
    
    public FileReader(string path, int delay, int itemsPerIteration)
    {
        _path = path;
        _itemsPerIteration = itemsPerIteration;
        _delay = delay;
    }

    private void ReadFile()
    {
        using var streamReader = new StreamReader(_path);
        while (!streamReader.EndOfStream)
        {
            for (var i = 0; i < _itemsPerIteration && !streamReader.EndOfStream; i++)
            {
                Console.WriteLine(streamReader.ReadLine());
            }
            Thread.Sleep(_delay);
        }
    }
    
    public void Start()
    {
        Task.Run(ReadFile);
    }
    
    public void StopReader()
    {
        TokenSource.Cancel();
        Task.Wait();
    }
}