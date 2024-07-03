using System.Globalization;

namespace BaseAlgorithms;

class Program
{
    static void WallAndStickConsole()
    {
        var englishCulture = CultureInfo.GetCultureInfo("en-US");
        double length = 0, step = 0;
        try
        {
            Console.Write("Insert length of stick (in meters): ");
            length = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert step of distance's change (in meters): ");
            step = double.Parse(Console.ReadLine()!, englishCulture);
            var conditions = AlgorithmsFunctions.WallAndStick(length, step);
            foreach (var condition in conditions)
            {
                Console.WriteLine($"{double.Round(condition.distance, 2)} m. => {double.Round(condition.angle, 2)}°");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    
    static void Main(string[] args)
    {
        Console.Write("1 - Task 1\n" +
                      "2 - Task 2\n" +
                      "3 - Task 3\n" +
                      "4 - Task 4\n" +
                      "5 - Task 5\n" +
                      "6 - Task 6\n" +
                      "Insert operation: ");
        var operation = int.Parse(Console.ReadLine() ?? string.Empty);
        switch (operation)
        {
            case 2:
                WallAndStickConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}