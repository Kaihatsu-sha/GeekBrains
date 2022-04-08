using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Kaihatsu.WPF.InformationWindows;

namespace Kaihatsu.ASPMVC.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {;
        IWindow errorWindow = WindowsFactory
            .GetFactory(this, WindowType.Confirm)
            .Create(
            title : "Заголовок",
            header :"Упс!!! Возникла ошибка",
            description :"Очень большое описание ошибки");

        errorWindow.ShowWindow();
    }
}
