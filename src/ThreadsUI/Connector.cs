using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Windows;

namespace ThreadsUI;

public class Connector
{
    private readonly MainWindow _window;
    private readonly Process _consoleProcess;
    private NamedPipeClientStream _clientStream;
    
    public Connector(string binName, MainWindow window)
    {
        _window = window;
        _consoleProcess = new Process();
        _consoleProcess.StartInfo.RedirectStandardInput = true;
        _consoleProcess.EnableRaisingEvents = true;
        _consoleProcess.StartInfo.UseShellExecute = false;
        _consoleProcess.StartInfo.FileName = binName;
        _consoleProcess.Start();
    }

    public bool HasExited => _consoleProcess.HasExited;
    
    private void StartReading()
    {
        var streamReader = new StreamReader(_clientStream);
        while (_clientStream.IsConnected)
        {
            var line = streamReader.ReadLine();
            _window.Dispatcher.BeginInvoke(() => _window.StringsOutputBox.Items.Add(line ?? string.Empty));
        }
    }
    
    public void SendCommand(string command)
    {
        _consoleProcess.StandardInput.WriteLine(command);
    }
    
    public void Start()
    {
        _clientStream = new NamedPipeClientStream(".", "appPipe", PipeDirection.In);
        _clientStream.Connect();
        Task.Run(StartReading);
    }
    
    public void Stop()
    {
        _consoleProcess.WaitForExit();
        _clientStream.Close();
    }
}