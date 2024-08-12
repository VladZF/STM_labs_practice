using System.Windows;
using System.Windows.Controls;

namespace ThreadsUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _launchedThreadsCount;
    private const int MaxThreads = 16;

    public MainWindow()
    {
        InitializeComponent();
        _launchedThreadsCount = 0;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if (ThreadCount.Text == "")
        {
            MessageBox.Show("Введите количество запускаемых потоков");
            return;
        }
        var threadForStartCount = int.Parse(ThreadCount.Text);
        if (threadForStartCount < 0)
        {
            MessageBox.Show("Количество запускаемых потоков должно быть положительным числом");
            return;
        }
        if (threadForStartCount == 0)
        {
            MessageBox.Show("Потоков не запущено");
            return;
        }
        if (_launchedThreadsCount + threadForStartCount > MaxThreads)
        {
            MessageBox.Show($"количество работающих потоков не должно превышать {MaxThreads}");
            return;
        }
        _launchedThreadsCount += threadForStartCount;
        WorkingThreadsInfoBlock.Text = $"Количество запущенных потоков: {_launchedThreadsCount}";
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
            return;
        }
        WorkingThreadsInfoBlock.Text = $"Количество запущенных потоков: {_launchedThreadsCount}";
    }

    private void StopAllButton_Click(object sender, RoutedEventArgs e)
    {
        _launchedThreadsCount = 0;
        WorkingThreadsInfoBlock.Text = "Ни один поток не запущен";
    }

    private void ThreadCount_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}