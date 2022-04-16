using Kaihatsu.ASPMVC.WPF.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kaihatsu.ASPMVC.WPF.Infrastructure.Extensions;

internal static class CommandDebugExtensions
{
    public static ICommand Debug(this ICommand command)
    {
        return new DebugCommand(command);
    }
}
