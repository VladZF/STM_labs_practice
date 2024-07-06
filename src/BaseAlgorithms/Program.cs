using System.Collections;
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
    
    public static void PutToHashTableByConsole(ref HashTable table)
    {
        Console.Write("Insert key: ");
        var key = Console.ReadLine()!;
        Console.Write("Insert value: ");
        var value = int.Parse(Console.ReadLine()!);
        table.Put(key, value);
        Console.WriteLine($"Added key '{key}' with value {value}");
    }
    
    public static void GetFromHashTableByConsole(ref HashTable table)
    {
        Console.Write("Insert key: ");
        var key = Console.ReadLine()!;
        var result = table.Get(key);
        Console.WriteLine($"value by key '{key}' is {result}");
    }
    
    public static void DeleteFromHashTableByConsole(ref HashTable table)
    {
        Console.Write("Insert key: ");
        var key = Console.ReadLine()!;
        table.Delete(key);
        Console.WriteLine($"key '{key}' is deleted");
    }
    
    public static void HashTableConsole()
    {
        var table = new HashTable();
        Console.Write("1 - Put new key with value\n" +
                      "2 - Get value by key\n" +
                      "3 - Delete key with it's value\n" +
                      "4 - Print table\n" +
                      "5 - Exit from command line\n" +
                      "Insert command: ");
        var command = int.Parse(Console.ReadLine()!);
        while (command != 5)
        {
            try
            {
                switch (command)
                {
                    case 1:
                        PutToHashTableByConsole(ref table);
                        break;
                    case 2:
                        GetFromHashTableByConsole(ref table);
                        break;
                    case 3:
                        DeleteFromHashTableByConsole(ref table);
                        break;
                    case 4:
                        Console.WriteLine(table);
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            

            Console.Write("Insert command: ");
            command = int.Parse(Console.ReadLine()!);
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
            case 6:
                HashTableConsole();
                break;
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}