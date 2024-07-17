namespace DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

public class InconsistentLimitsException : ArgumentException
{
    public char[] IntersectedChars { get; init; }
    
    public InconsistentLimitsException(char[] intersectedChars) : 
        base($"There are intersected chars in prohibition and erroneous strings: {string.Join(", ", intersectedChars)}")
    {
        IntersectedChars = intersectedChars;
    }
    
    public InconsistentLimitsException(char[] intersectedChars, string message) : base(message)
    {
        IntersectedChars = intersectedChars;
    }
}