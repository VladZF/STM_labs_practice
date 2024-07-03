using System.Globalization;

namespace BaseAlgorithms;

class Program
{
    static void WallAndStickConsole()
    {
        var englishCulture = CultureInfo.GetCultureInfo("en-US");
        double length = 0, distance = 0, step = 0;
        try
        {
            Console.Write("Insert length of stick: ");
            length = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert distance between wall and bottom end of stick: ");
            distance = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert step of distance's change: ");
            step = double.Parse(Console.ReadLine()!, englishCulture);
            var answerList = Solution.WallAndStick(length, distance, step);
            foreach (var angle in answerList)
            {
                Console.WriteLine($"{double.Round(angle, 2)} ");
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