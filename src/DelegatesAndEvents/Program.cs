using System.Globalization;
using DelegatesAndEvents.Task5Classes;

namespace DelegatesAndEvents;

public static class Program
{
    private static void CalculatorConsole()
    {
        var englishCulture = CultureInfo.GetCultureInfo("en-US");
        try
        {
            Console.Write("Insert first number: ");
            var firstNumber = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert second number: ");
            var secondNumber = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("'+' - sum\n" +
                          "'-' - subtract\n" +
                          "'*' - multiply\n" +
                          "'/' - divide\n" +
                          "Insert operation: ");
            var operation = Console.ReadLine()!.Trim();
            var result = Calculator.GetResult(firstNumber, secondNumber, operation);
            Console.WriteLine($"Result: {result.ToString(englishCulture)}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    
    private static void StringLoaderConsole()
    {
        var loader = new LimitedStringLoader("ABC", "XYZ", 3);
        loader.Load("LoaderTest.txt");
        Console.WriteLine($"Loaded: {loader.LoadedStrings.Count()} line(s)");
        Console.WriteLine($"Prohibited: {loader.ProhibitionCount} line(s)");
        foreach (var row in loader.LoadedStrings)
        {
            Console.WriteLine(row);
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("1 - Task 1\n" +
                      "2 - Task 2\n" +
                      "3 - Task 3\n" +
                      "4 - Task 4\n" +
                      "5 - Task 5\n" +
                      "Insert operation: ");
        var operation = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (operation)
        {
            case 1:
                CalculatorConsole();
                break;
            case 5:
                StringLoaderConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}