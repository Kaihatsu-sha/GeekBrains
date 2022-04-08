using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kaihatsu.WPF.InformationWindows.Factories;

internal class ConfirmWindowFactory : IWindowsFactory
{
    private readonly Window _owner;

    internal ConfirmWindowFactory(Window owner)
    {
        _owner = owner;
    }

    public IWindow Create()
    {
        return new ConfirmWindow(_owner);
    }

    public IWindow Create(string title, string header, string description, double height = 150, double width = 200)
    {
        return new ConfirmWindow(_owner)
        {
            TitleWindow = title,
            Header = header,
            Description = description,
            CurrentHeight = height,
            CurrentWidth = width
        };
    }
}
