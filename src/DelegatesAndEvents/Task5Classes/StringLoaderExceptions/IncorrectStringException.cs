namespace DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

public class IncorrectStringException : Exception
{
    public int RowNumber { get; init; }
    
    public IncorrectStringException(int rowNumber) : base($"Row {rowNumber} has incorrect format")
    {
        RowNumber = rowNumber;
    }
    
    public IncorrectStringException(int rowNumber, string message) : base(message)
    {
        RowNumber = rowNumber;
    }
}