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
        try
        {
            Console.WriteLine("Insert toys list (without spaces in names):");
            var toysString = Console.ReadLine() ?? string.Empty;
            if (toysString.Length == 0)
            {
                Console.WriteLine("No toys found");
                return;
            } 
            var toysList = toysString.Split().ToHashSet();
            var city = new City(toysList);
            Console.Write("Insert gardens count: ");
            var gardensCount = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Insert number of garden and all toys that contain in it in each row:");
            for (var gardenCounter = 0; gardenCounter < gardensCount; gardenCounter++)
            {
                var data = Console.ReadLine()!.Split();
                var id = int.Parse(data[0]);
                var toys = data[1..].ToHashSet();
                var garden = new KinderGarden(id, toys);
                city.AddGarden(garden);
            }

            Console.WriteLine("Toys found in all gardens:");
            if (city.GetToysFoundInAllGardens.Count == 0)
                Console.WriteLine('-');
            foreach (var toy in city.GetToysFoundInAllGardens)
            {
                Console.WriteLine(toy);
            }

            Console.WriteLine("Toys not found in any garden:");
            if (city.GetToysNotFoundInAnyGarden.Count == 0)
                Console.WriteLine('-');
            foreach (var toy in city.GetToysNotFoundInAnyGarden)
            {
                Console.WriteLine(toy);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
  
    static void GetWeekDayConsole()
    {
        try
        {
            Console.Write("Insert a year: ");
            var year = int.Parse(Console.ReadLine()!);
            Console.Write("Insert day of year: ");
            var day = int.Parse(Console.ReadLine()!);
            if (day is < 1 or > 365)
            {
                Console.WriteLine("Error: this is not number of day in year");
                return;
            }
            
            
            var dayName = AlgorithmsFunctions.GetWeekDay(day, year);
            Console.WriteLine(dayName);
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
            case 2:
                WallAndStickConsole();
                break;
            case 3:
                CompressBinarySequenceConsole();
                break;
            case 4:
                ToysInKinderGardensConsole();
                break;
            case 5:
                GetWeekDayConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}