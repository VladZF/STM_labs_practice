using System.Globalization;
using DelegatesAndEvents.Task3Classes;

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
    
    private static void QuadraticFunctionConsole()
    {
        try
        {
            Console.Write("Insert elder coefficient: ");
            var elderCoefficient = int.Parse(Console.ReadLine()!);
            Console.Write("Insert middle coefficient: ");
            var middleCoefficient = int.Parse(Console.ReadLine()!);
            Console.Write("Insert free coefficient: ");
            var freeCoefficient = int.Parse(Console.ReadLine()!);
            var polynomial = QuadraticPolynomial.GetPolynomial(elderCoefficient, middleCoefficient, freeCoefficient);
            Console.WriteLine("Insert count of argument values for insert: ");
            var argCount = int.Parse(Console.ReadLine()!);
            for (var counter = 0; counter < argCount; counter++)
            {
                Console.Write("Insert argument: ");
                var argument = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"argument: {argument}; value: {polynomial(argument)}");
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
            case 3:
                QuadraticFunctionConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}