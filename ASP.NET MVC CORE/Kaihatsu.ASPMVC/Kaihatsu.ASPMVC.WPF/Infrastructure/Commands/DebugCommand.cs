using Kaihatsu.ASPMVC.WPF.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kaihatsu.ASPMVC.WPF.Infrastructure.Commands
{
    // Декоратор
    internal class DebugCommand : CommandBase
    {
        private readonly ICommand _command;

        public DebugCommand(ICommand command)
        {
            _command = command;
        }

        public override void Execute(object? parameter)
        {
            Debug.WriteLine("Выполняется команнда {0}", _command);
            _command.Execute(parameter);
        }

        public override bool CanExecute(object? parameter)
        {
            return _command.CanExecute(parameter);
        }
    }
}
