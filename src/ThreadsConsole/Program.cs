using System.IO.Pipes;

namespace ThreadsConsole;

class Program
{
    static void Main(string[] args)
    {
        var threadController = new ThreadController();
        var serverStream = new NamedPipeServerStream(".", PipeDirection.Out);
        serverStream.WaitForConnection();
        Console.WriteLine("Connected");
        var command = string.Empty;
        while (command != "Stop all")
        {
            command = Console.ReadLine();
            if (command.StartsWith("Start"))
            {
                
            }
            switch (command)
            {
                case "Stop":
                    break;
                case "Stop all":
                    continue;
            }
        }
        
    }
}