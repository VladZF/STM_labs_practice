namespace DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

public class DataNotLoadedException : InvalidOperationException
{
    public DataNotLoadedException() : base("You need load strings in loader before call property")
    {
    }

    public DataNotLoadedException(string message) : base(message)
    {
    }
}