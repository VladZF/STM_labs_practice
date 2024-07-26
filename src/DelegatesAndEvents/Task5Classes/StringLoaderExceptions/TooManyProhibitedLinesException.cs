namespace DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

public class TooManyProhibitedLinesException : Exception
{
    public TooManyProhibitedLinesException() : base("Count of prohibited lines greater than maximum prohibition limit")
    {
    }
    
    public TooManyProhibitedLinesException(int limit) : base($"Count of prohibited lines greater than {limit}")
    {
    }
    
    public TooManyProhibitedLinesException(int limit, string message) : base(message)
    {
    }
}