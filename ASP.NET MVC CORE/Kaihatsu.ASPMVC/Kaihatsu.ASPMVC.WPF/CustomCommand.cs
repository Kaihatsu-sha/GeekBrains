using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kaihatsu.ASPMVC.WPF;

// Построитель
public class CustomCommand : ICommand
{
    private Func<object, bool> _canExecute;
    private Action<object> _action;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    public bool CanExecute(object? parameter)
    {
        Debug.WriteLine("CanExecute");
        return true;// _canExecute?.Invoke(parameter);
        //throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        Debug.WriteLine("Execute");
        _action?.Invoke(parameter);
        //throw new NotImplementedException();
    }
}
