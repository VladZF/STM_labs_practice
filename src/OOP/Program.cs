using OOP.Enums;

namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insert path to file with clients info:");
        var filepath = Console.ReadLine()!;
        var bank = new BankApplication(new DataBase(filepath));
        bank.Start();
    }
}