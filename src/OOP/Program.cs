using OOP.Enums;

namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Insert path to file with clients info:");
            var filepath = Console.ReadLine()!;
            if (!filepath.EndsWith(".json"))
            {
                Console.WriteLine("Error: File must be .json");
                return;
            }
            var bank = new BankApplication(new DataBase(filepath));
            bank.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in DataBase connection to file.\nError message: {e.Message}");
        }
    }
}