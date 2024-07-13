using System.Globalization;
using DelegatesAndEvents.Task4Classes;

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

    private static void EventConsole()
    {
        try
        {
            var coolMessenger = new Poster("Cool messenger");
            var wallOfArts = new Poster("Wall of arts");
            var handlers = new EventHandlers();
            coolMessenger.OnPostAdded += handlers.WhenAdded;
            coolMessenger.OnPostDeleted += handlers.WhenDeleted;
            wallOfArts.OnPostAdded += handlers.WhenAdded;
            wallOfArts.OnPostDeleted += handlers.WhenDeleted;
            wallOfArts.AddPost("Picture", "Mona Liza is very beautiful woman");
            coolMessenger.AddPost("Party", "Today we party the 20th birthday of our friend Peter");
            coolMessenger.AddPost("Army", "So, I will go to the army yesterday. Wish me good luck");
            coolMessenger.DeletePost("Party");
            wallOfArts.DeletePost("Picture");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message);
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
            case 4:
                EventConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}