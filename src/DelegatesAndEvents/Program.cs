using System.Globalization;
using DelegatesAndEvents.Task4Classes;
using EventHandler = DelegatesAndEvents.Task4Classes.EventHandler;

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
            var morning = new Post("Morning", "There are many birds out of window at this morning!");
            var party = new Post("Birthday", "Today we party birthday of our friend Peter");
            var handler = new EventHandler();
            morning.Subscribe(handler.Handler);
            party.Subscribe(handler.Handler);
            morning.Title = "Birds";
            party.Text = "Today we party the 20th birthday of our friend Peter in night club";
            morning.Text = "";
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