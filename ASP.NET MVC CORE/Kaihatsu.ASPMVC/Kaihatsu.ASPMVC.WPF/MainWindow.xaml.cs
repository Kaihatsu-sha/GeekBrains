using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kaihatsu.ASPMVC.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _timeout = 1_000;
    private bool _isRun = false;
    private FibonacceThread _fibonacceThread;

    public MainWindow()
    {
        InitializeComponent();
        FibonacceTextBlock.Text = "";
        _fibonacceThread = new FibonacceThread(AddToTextBlock, _timeout);
    }

    private void CancelBtnClick(object sender, RoutedEventArgs e)
    {
        FibonacceTextBlock.Text += "STOP!!!";
        //_fibonacceThread.StopJoin();
        try
        {
            _fibonacceThread.StopInterrupt();
        }
        catch (ThreadInterruptedException ex)
        {

        }
        finally 
        {
            FibonacceTextBlock.Text += "STOP!!!";
        }
    }

    private void StartBtnClick(object sender, RoutedEventArgs e)
    {
        _isRun = true;
        _fibonacceThread.Run();
        ((Button)sender).IsEnabled = false;
        StopBtn.IsEnabled = true;
    }

    private void AddToTextBlock(long value)
    {
        Dispatcher.Invoke(() => FibonacceTextBlock.Text += $"{value} ");//Вызывается в другом потоке
    }

    private void ChangeTimeout(double roundValue)
    {
        if (_isRun)
        {
            _fibonacceThread.Timeout = 1_000 * (int)roundValue;
        }
        else
        {
            _timeout = 1_000 * (int)roundValue;
        }
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Slider ss = (Slider)sender;
        double valueSlider = ss.Value;
        double roundValue = Math.Round(valueSlider, MidpointRounding.ToEven);
        ss.Value = roundValue;
        ChangeTimeout(roundValue);
    }
}
