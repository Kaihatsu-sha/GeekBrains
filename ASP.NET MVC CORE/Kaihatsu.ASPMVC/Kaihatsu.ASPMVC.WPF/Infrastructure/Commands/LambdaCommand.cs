

using Kaihatsu.ASPMVC.WPF.Infrastructure.Commands.Base;
using System;

namespace Kaihatsu.ASPMVC.WPF.Infrastructure.Commands;

internal class LambdaCommand : CommandBase
{
    Action<object?> _onExecute;
    Func<object?, bool>? _onCanExecute;

    public LambdaCommand(Action<object?> onExecute, Func<object?, bool>? onCanExecute = null)
    {
        _onExecute = onExecute;
        _onCanExecute = onCanExecute;
    }

    public override bool CanExecute(object? parameter)
    {
        return base.CanExecute(parameter) && (_onCanExecute?.Invoke(parameter) ?? true);
    }
    public override void Execute(object? parameter)
    {
        _onExecute.Invoke(parameter);
    }
}
