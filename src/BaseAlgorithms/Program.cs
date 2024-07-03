using System.Globalization;

namespace BaseAlgorithms;

class Program
{
    static void CompressBinarySequenceConsole()
    {
        Console.Write("Insert sequence: ");
        try
        {
            var sequence = Console.ReadLine()!;
            var compressed = AlgorithmsFunctions.CompressBinarySequence(sequence);
            Console.WriteLine($"Compressed sequence: {compressed}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
          
    static void IsTriangleExistsConsole()
    {
        var englishCulture = CultureInfo.GetCultureInfo("en-US");
        double firstAngle = 0.0, secondAngle = 0.0;
        try
        {
            Console.Write("Insert angle A: ");
            firstAngle = double.Parse(Console.ReadLine()!, englishCulture);
            Console.Write("Insert angle B: ");
            secondAngle = double.Parse(Console.ReadLine()!, englishCulture);
        }
        catch (FormatException e)
        {
            Console.WriteLine("ERROR: Wrong format of angle");
            return;
        }
        catch (OverflowException e)
        {
            Console.WriteLine("ERROR: Angle value is greater than double");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
            return;
        }

        var triangleFactors = AlgorithmsFunctions.IsTriangleExists(firstAngle, secondAngle);
        if (triangleFactors.isExists)
        {
            Console.WriteLine("Triangle exists");
            Console.WriteLine(triangleFactors.isRightAngled ? "Triangle is right-angled" : "Triangle is not right-angled");
        } 
        else
        {
            Console.WriteLine("Triangle does not exists");
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
            case 1:
                IsTriangleExistsConsole();
                break;
            case 3:
                CompressBinarySequenceConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}