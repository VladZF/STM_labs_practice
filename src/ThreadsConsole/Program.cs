using System.IO.Pipes;

namespace ThreadsConsole;

class Program
{
    static void Main(string[] args)
    {
        const string filename = "text.txt";
        var serverStream = new NamedPipeServerStream("appPipe", PipeDirection.Out);
        serverStream.WaitForConnection();
        var threadController = new ThreadController(serverStream);
        Console.WriteLine("Connected");
        var command = string.Empty;
        while (command != "Stop all")
        {
            command = Console.ReadLine();
            if (string.IsNullOrEmpty(command))
            {
                continue;
            }
            if (command.StartsWith("Start"))
            {
                var commandData = command.Split();
                var count = int.Parse(commandData[1]);
                var delay = int.Parse(commandData[2]);
                var itemsPerIteration = int.Parse(commandData[3]);
                threadController.AddReaders(filename, delay, itemsPerIteration, count);
                continue;
            }
            if (command == "Stop")
            {
                threadController.RemoveLastReader();
            }
            if (command == "Stop all")
            {
                break;
            }
        }
        
    }
}