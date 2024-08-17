namespace ThreadsConsole;

public class ThreadController
{
    private List<FileReader> _readers = [];

    public void AddReader(string path, int delay, int itemsPerIteration)
    {
        _readers.Add(new FileReader(path, delay, itemsPerIteration));
    }
    
    public void RemoveLastReader()
    {
        _readers.Last().StopReader();
        _readers.RemoveAt(_readers.Count - 1);
    }
}