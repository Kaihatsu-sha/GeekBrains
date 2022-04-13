using Kaihatsu.WPF.InformationWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kaihatsu.ASPMVC.WPF
{
    public class CreateWindowCommand : ICommand
    {
        private readonly IWindowsFactory _factory;
        public IWindow CurrentWindow {get; private set;}

        public CreateWindowCommand(IWindowsFactory factory, WindowContent? content)
        {
            _factory = factory;
            if(content is null)
            {
                CurrentWindow = _factory.Create();
                return;
            }                

            CurrentWindow = _factory.Create(content.Title, content.Header, content.Description);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if(CurrentWindow is null)
                return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            CurrentWindow.ShowWindow();
        }
    }
}
