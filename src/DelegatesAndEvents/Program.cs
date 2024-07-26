using System.Globalization;
using DelegatesAndEvents.Task2Classes;
using DelegatesAndEvents.Task3Classes;
using DelegatesAndEvents.Task4Classes;
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

    private static void QuadraticFunctionConsole()
    {
        var englishCulture = CultureInfo.GetCultureInfo("en-US");
        try
        {
            Console.Write("Insert elder coefficient: ");
            var elderCoefficient = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert middle coefficient: ");
            var middleCoefficient = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert free coefficient: ");
            var freeCoefficient = double.Parse(Console.ReadLine()!, englishCulture);
            var polynomial = QuadraticPolynomial.GetPolynomial(elderCoefficient, middleCoefficient, freeCoefficient);
            Console.WriteLine("Insert count of argument values for insert: ");
            var argCount = int.Parse(Console.ReadLine()!);
            for (var counter = 0; counter < argCount; counter++)
            {
                Console.Write("Insert argument: ");
                var argument = double.Parse(Console.ReadLine()!, englishCulture);
                Console.WriteLine($"argument: {argument.ToString(englishCulture)}; value: {polynomial(argument).ToString(englishCulture)}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message);
        }
    }
              
    private static void WeekDaysConsole()
    {
        try
        {
            Console.Write("Insert count of days for output: ");
            var daysCount = int.Parse(Console.ReadLine()!);
            if (daysCount < 1)
            {
                Console.WriteLine("ERROR: number is not natural");
            }

            var weekDays = WeekDays.GiveWeekDays();
            for (var day = 1; day <= daysCount; day++)
            {
                Console.WriteLine($"day {day}: {weekDays()}");
            }
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
            case 2:
                WeekDaysConsole();
                break;
            case 3:
                QuadraticFunctionConsole();
                break;
            case 4:
                EventConsole();
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