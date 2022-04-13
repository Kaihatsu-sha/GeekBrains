using Kaihatsu.WPF.InformationWindows.Factories;
using System;
using System.Windows;

namespace Kaihatsu.WPF.InformationWindows;

public enum WindowType
{
    Information,
    Confirm,
    Error
}

public static class WindowsFactory
{
    public static IWindowsFactory GetFactory(Window owner, WindowType type)
    {
        if(owner is null)
            throw new ArgumentNullException(nameof(owner));

        return type switch
        {                
            WindowType.Information => new InformationWindowFactory(owner),
            WindowType.Confirm => new ConfirmWindowFactory(owner),
            WindowType.Error => new ErrorWindowFactory(owner),                
            _ => throw new ArgumentException(nameof(type))
        };
    }
}


