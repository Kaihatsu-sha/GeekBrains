using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kaihatsu.WPF.InformationWindows;

public interface IWindow
{
    //public ICommand? ConfirmCommand { get; set; }
    public event Action EventСancellation;
    public event Action EventConfirmation;
    public string TitleWindow { get; set; }
    public string Header { get; set; }
    public string Description { get; set; }
    public double CurrentHeight { get; set; }
    public double CurrentWidth { get; set; }

    public void ShowWindow();
    public void CloseWindow();
}
