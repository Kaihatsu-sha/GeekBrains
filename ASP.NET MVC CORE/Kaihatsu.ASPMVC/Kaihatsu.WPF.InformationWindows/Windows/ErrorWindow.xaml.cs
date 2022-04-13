using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Kaihatsu.WPF.InformationWindows;

/// <summary>
/// Interaction logic for ErrorWindow.xaml
/// </summary>
public partial class ErrorWindow : Window, IWindow
{
    public string TitleWindow { get; set; }
    public string Header { get; set; }
    public string Description { get; set; }
    public double CurrentHeight { get; set; }
    public double CurrentWidth { get; set; }

    public event Action EventСancellation;
    public event Action EventConfirmation;

    internal ErrorWindow(Window owner)
    {
        InitializeComponent();
        Owner = owner;
    }

    private void Initialize()
    {
        ResizeMode = ResizeMode.NoResize;
        Closing += InvokeClosingEvent;

        Title = TitleWindow;
        Height = CurrentHeight;
        Width = CurrentWidth;

        ErrorDescription.Text = Description;
        HeaderLabel.Content = Header;
    }

    public void ShowWindow()
    {
        Initialize();
        ShowDialog();
    }

    public void CloseWindow()
    {
        EventСancellation = null;
        Close();
    }

    private void InvokeClosingEvent(object? sender, CancelEventArgs e)
    {
        EventСancellation?.Invoke();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        CloseWindow();
        EventConfirmation?.Invoke();
    }
}
