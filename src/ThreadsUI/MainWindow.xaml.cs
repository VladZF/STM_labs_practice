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
    private int _launchedThreadsCount;
    private int _threadsForStartCount;
    private int _delayForStart;
    private int _itemsPerIterationForStart;
    private int _lastThreadNumber = 1;

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
        _launchedThreadsCount += 2;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        if (_threadsForStartCount == 0)
        {
            return;
        }
        if (_launchedThreadsCount == 0)
        {
            OpenConsole();
        }
        _connector.SendCommand($"Start {_threadsForStartCount} {_delayForStart} {_itemsPerIterationForStart}");
        _launchedThreadsCount += _threadsForStartCount;
        ActiveThreadsList.Items.Add($"Поток {_lastThreadNumber}");
        _lastThreadNumber++;
        StopButton.IsEnabled = true;
        StopAllButton.IsEnabled = true;
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        if (_launchedThreadsCount > 0)
        {
            _launchedThreadsCount--;
        }
        if (_launchedThreadsCount == 0) 
        {
            MessageBox.Show("Все потоки остановлены");
            StopButton.IsEnabled = false;
            StopAllButton.IsEnabled = false;
        }
    }

    private void StopAllButton_Click(object sender, RoutedEventArgs e)
    {
        _launchedThreadsCount = 0;
        MessageBox.Show("Все потоки остановлены");
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
    }

    private void ThreadCount_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text == "")
        {
            _launchedThreadsCount = 0;
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
            _launchedThreadsCount = 0;
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
            _launchedThreadsCount = 0;
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
}