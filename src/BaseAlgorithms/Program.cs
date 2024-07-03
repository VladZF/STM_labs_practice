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
    
    static void ToysInKinderGardensConsole()
    {
        List<HashSet<string>> gardens = [];
        HashSet<string> toys = [];
        try
        {
            Console.Write("Insert gardens count: ");
            var gardensCount = int.Parse(Console.ReadLine() ?? string.Empty);
            for (var counter = 0; counter < gardensCount; ++counter)
            {
                gardens.Add([]);
            }
            Console.Write("Insert number of toys: ");
            var toysCount = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Insert toys list in format <toy name> <gardens' numbers in interval [0..gardensCount)>:");
            for (var counter = 0; counter < toysCount; ++counter)
            {
                var data = Console.ReadLine()!.Split();
                if (data.Length == 0 || data[0].Length == 0)
                {
                    Console.WriteLine("Error: Empty toy name");
                    return;
                }

                var toy = data[0];
                var gardenNumbers = data[1..].Select(int.Parse).ToArray();
                toys.Add(toy);
                foreach (var number in gardenNumbers)
                {
                    if (number >= gardensCount)
                    {
                        Console.WriteLine($"Error: there is no garden with number {number}");
                        return;
                    }
                    gardens[number].Add(toy);
                }
            }

            var statistics = AlgorithmsFunctions.ToysInKinderGardens(toys, gardens);
            Console.WriteLine("All gardens contain these toys:");
            if (statistics.everywhere.Count == 0)
            {
                Console.WriteLine('-');
            }
            foreach (var toy in statistics.everywhere)
            {
                Console.WriteLine(toy);
            }
            Console.WriteLine("All gardens does not contain these toys:");
            if (statistics.nowhere.Count == 0)
            {
                Console.WriteLine('-');
            }
            foreach (var toy in statistics.nowhere)
            {
                Console.WriteLine(toy);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
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
            case 4:
                ToysInKinderGardensConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}