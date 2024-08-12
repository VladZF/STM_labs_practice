using OOP.Enums;

namespace OOP;

class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Insert path to file with clients info:");
            var clientsPath = Console.ReadLine()!;
            if (!clientsPath.EndsWith(".json"))
            {
                Console.WriteLine("Error: File must be .json");
                return;
            }
            Console.WriteLine("Insert path to file with changes info:");
            var changesPath = Console.ReadLine()!;
            if (!changesPath.EndsWith(".json"))
            {
                Console.WriteLine("Error: File must be .json");
                return;
            }
            var bank = new BankApplication(new DataBase(clientsPath, changesPath));
            bank.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error in DataBase connection to file.\nError message: {e.Message}");
        }
    }
}