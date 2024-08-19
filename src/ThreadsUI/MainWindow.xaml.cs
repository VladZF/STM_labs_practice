using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ThreadsUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Connector _connector;
    private int LaunchedThreadsCount => ActiveThreadsList.Items.Count;
    private int _threadsForStartCount;
    private int _delayForStart;
    private int _itemsPerIterationForStart;
    private int LastThreadNumber => ActiveThreadsList.Items.Count - 1;

    public MainWindow()
    {
        InitializeComponent();
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
    }

    private void OpenConsole()
    {
        _connector = new Connector("ThreadsConsole.exe", this);
        _connector.Start();
        ActiveThreadsList.Items.Add("Все потоки");
        ActiveThreadsList.Items.Add("Главный поток");
    }
    
    private void CloseConsole()
    {
        _connector.SendCommand("Stop all");
        _connector.Stop();
        ActiveThreadsList.Items.Clear();
        StringsOutputBox.Items.Clear();
    }
    
    public void IfConsoleClosedByUser()
    {
        _connector.Stop();
        ActiveThreadsList.Items.Clear();
        StringsOutputBox.Items.Clear();
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
        MessageBox.Show("Консоль закрыта");
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        if (_threadsForStartCount == 0)
        {
            MessageBox.Show("Потоков не запущено");
            return;
        }
        if (_delayForStart == 0)
        {
            MessageBox.Show("Задержка между выводами должна быть ненулевая");
            return;
        }
        if (_itemsPerIterationForStart == 0)
        {
            MessageBox.Show("Количество выводимых строк за итерацию должно быть ненулевым");
            return;
        }
        if (LaunchedThreadsCount == 0)
        {
            OpenConsole();
        }
        _connector.SendCommand($"Start {_threadsForStartCount} {_delayForStart} {_itemsPerIterationForStart}");
        for (var _ = 0; _ < _threadsForStartCount; _++)
        {
            ActiveThreadsList.Items.Add($"Поток {LastThreadNumber}");
        }
        StopButton.IsEnabled = true;
        StopAllButton.IsEnabled = true;
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        if (LaunchedThreadsCount > 2)
        {
            _connector.SendCommand("Stop");
            ActiveThreadsList.Items.RemoveAt(ActiveThreadsList.Items.Count - 1);
            return;
        }
        CloseConsole();
        MessageBox.Show("Все потоки остановлены");
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
        StringsOutputBox.Items.Clear();
    }

    private void StopAllButton_Click(object sender, RoutedEventArgs e)
    {
        CloseConsole();
        MessageBox.Show("Все потоки остановлены");
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
        StringsOutputBox.Items.Clear();
    }

    private void ThreadCount_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text == "")
        {
            return;
        }
        try
        {
            _threadsForStartCount = int.Parse(textBox.Text);
        }
        catch (FormatException)
        {
            MessageBox.Show("Вы ввели символ отличный от цифры");
            textBox.Clear();
        }
        catch (Exception)
        {
            MessageBox.Show("Произошла ошибка");
            textBox.Clear();
        }
    }

    private void Delay_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text == "")
        {
            return;
        }
        try
        {
            _delayForStart = int.Parse(textBox.Text);
        }
        catch (FormatException)
        {
            MessageBox.Show("Вы ввели символ отличный от цифры");
            textBox.Clear();
        }
        catch (Exception)
        {
            MessageBox.Show("Произошла ошибка");
            textBox.Clear();
        }
    }

    private void ItemsPerIteration_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text == "")
        {
            return;
        }
        try
        {
            _itemsPerIterationForStart = int.Parse(textBox.Text);
        }
        catch (FormatException)
        {
            MessageBox.Show("Вы ввели символ отличный от цифры");
            textBox.Clear();
        }
        catch (Exception)
        {
            MessageBox.Show("Произошла ошибка");
            textBox.Clear();
        }
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (_connector is { HasExited: false })
        {
            CloseConsole();
        }
    }
}