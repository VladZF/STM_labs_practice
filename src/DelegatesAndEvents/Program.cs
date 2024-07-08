namespace DelegatesAndEvents;

class Program
{
    static void Main(string[] args)
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
            default:
                Console.WriteLine("Incorrect operation");
                break;
        }
    }
}