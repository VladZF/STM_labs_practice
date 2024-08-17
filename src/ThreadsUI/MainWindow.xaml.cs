using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace ThreadsUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _launchedThreadsCount;
    private int _threadsForStartCount;
    private int _delayForStart;
    private int _itemsPerIterationForStart;
    private const int MaxThreads = 16;

    public MainWindow()
    {
        InitializeComponent();
        _launchedThreadsCount = 0;
        StopButton.IsEnabled = false;
        StopAllButton.IsEnabled = false;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        if (_threadsForStartCount == 0)
        {
            MessageBox.Show("Потоков не было запущено");
        }

        if (_launchedThreadsCount + _threadsForStartCount > MaxThreads)
        {
            MessageBox.Show($"Количество запущенных потоков должно быть не больше {MaxThreads}");
            return;
        }
        _launchedThreadsCount += _threadsForStartCount;
        WorkingThreadsInfoBlock.Text = $"Количество запущенных потоков: {_launchedThreadsCount}";
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
            WorkingThreadsInfoBlock.Text = "Ни один поток не запущен";
            StopButton.IsEnabled = false;
            StopAllButton.IsEnabled = false;
            return;
        }
        WorkingThreadsInfoBlock.Text = $"Количество запущенных потоков: {_launchedThreadsCount}";
    }

    private void StopAllButton_Click(object sender, RoutedEventArgs e)
    {
        _launchedThreadsCount = 0;
        MessageBox.Show("Все потоки остановлены");
        WorkingThreadsInfoBlock.Text = "Ни один поток не запущен";
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