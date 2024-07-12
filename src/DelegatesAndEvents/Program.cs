using System.Globalization;
using DelegatesAndEvents.Task2Classes;

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
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}