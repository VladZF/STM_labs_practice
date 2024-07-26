namespace DelegatesAndEvents.Task5Classes.StringLoaderExceptions;

public class WrongStartingSymbolException : IncorrectStringException
{
    public char StartingSymbol { get; init; }

    public WrongStartingSymbolException(int rowNumber, char startingSymbol)
        : base(rowNumber, $"Row starting with erroneous symbol '{startingSymbol}' at row {rowNumber}")
    {
        StartingSymbol = startingSymbol;
    }

    public WrongStartingSymbolException(int rowNumber, char startingSymbol, string message) : base(rowNumber, message)
    {
        StartingSymbol = startingSymbol;
    }
}