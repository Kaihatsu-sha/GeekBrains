using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kaihatsu.WPF.InformationWindows;

public interface IWindowsFactory
{
    public IWindow Create();
    public IWindow Create(string title, string header, string description, double height = 150, double width = 200); 
}
