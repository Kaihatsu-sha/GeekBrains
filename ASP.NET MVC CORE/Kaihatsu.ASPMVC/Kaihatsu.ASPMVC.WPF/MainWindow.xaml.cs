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
    private readonly IWindowsFactory _errorWindowsFactory;
    private readonly IWindowsFactory _confirmWindowsFactory;
    private readonly IWindowsFactory _informationWindowsFactory;

    public CreateWindowCommand _errorWindow;
    public CreateWindowCommand _confirmWindow;
    public CreateWindowCommand _informationWindow;

    WindowContent InformationContent;
    WindowContent ConfirmContent;
    WindowContent ErrorContent;



    public CreateWindowCommand ShowErrorWindow
    {
        get
        {
            return _errorWindow ??= new CreateWindowCommand(_errorWindowsFactory, ErrorContent);
        }
    }

    public CreateWindowCommand ShowConfirmWindow
    {
        get
        {
            return _confirmWindow ??= new CreateWindowCommand(_confirmWindowsFactory, ConfirmContent);
        }
    }

    public CreateWindowCommand ShowInformationWindow
    {
        get
        {
            return _informationWindow ??= new CreateWindowCommand(_informationWindowsFactory, InformationContent);
        }
    }

    public MainWindow()
    {
        CreateWindowContent();
        InitializeComponent();
        DataContext = this;

        _errorWindowsFactory = WindowsFactory.GetFactory(this, WindowType.Error);
        _confirmWindowsFactory = WindowsFactory.GetFactory(this, WindowType.Confirm);
        _informationWindowsFactory = WindowsFactory.GetFactory(this, WindowType.Information);
    }

    private void CreateWindowContent()
    {
        InformationContent = new WindowContent { Title = "Информация", Header = "Внимание!!!", Description = "Ставки на спорт" };
        ConfirmContent = new WindowContent { Title = "Подтверждение", Header = "Подтвердите действие", Description = "Вы точно уверены??" };
        ErrorContent = new WindowContent { Title = "Ошибка", Header = "Произошла ошибка", Description = "NullReferenceException" };
    }
}
