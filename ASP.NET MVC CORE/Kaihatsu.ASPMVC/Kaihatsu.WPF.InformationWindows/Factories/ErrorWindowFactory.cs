using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kaihatsu.WPF.InformationWindows.Factories;

internal class ErrorWindowFactory : IWindowsFactory
{
    private readonly Window _owner;

    internal ErrorWindowFactory(Window owner)
    {
        _owner = owner;
    }

    public IWindow Create()
    {
        return Create("Error", "default header", "default description");
    }

    public IWindow Create(string title, string header, string description, double height = 150, double width = 200)
    {
        return new ErrorWindow(_owner)
        {
            TitleWindow = title,
            Header = header,
            Description = description,
            CurrentHeight = height,
            CurrentWidth = width
        };
    }
}
