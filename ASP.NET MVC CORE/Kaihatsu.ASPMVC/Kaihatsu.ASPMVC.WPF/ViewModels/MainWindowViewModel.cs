using Kaihatsu.ASPMVC.WPF.Infrastructure.Commands;
using Kaihatsu.ASPMVC.WPF.ViewModels.Base;
using Kaihatsu.WPF.InformationWindows;

namespace Kaihatsu.ASPMVC.WPF.ViewModels;

internal class MainWindowViewModel : ViewModelBase
{

    private string _title = "Главное окно программы";

    public string Title
    {
        get => _title;
        set => Set<string>(ref _title, value);
    }

    private LambdaCommand _showWindow;

    public LambdaCommand ShowWindow
    {
        get
        {
            return _showWindow ??= new LambdaCommand(ExecuteMain);
        }
    }


    private void ExecuteMain(object? parameter)
    {
        if (parameter is null)
            return;

        WindowType type = WindowType.Information;

        if (parameter is WindowType)
            type = (WindowType)parameter;

        switch (type)
        {
            case WindowType.Information:
                WindowsFactory
            .GetFactory(App.Current.MainWindow, type)
            .Create(
                title: "Информация",
                header: "Внимание!!!",
                description: "Ставки на спорт")
            .ShowWindow();
                break;
            case WindowType.Error:
                WindowsFactory
            .GetFactory(App.Current.MainWindow, type)
            .Create(
                title: "Ошибка",
                header: "Произошла ошибка",
                description: "NullReferenceException")
            .ShowWindow();
                break;
            case WindowType.Confirm:
                WindowsFactory
            .GetFactory(App.Current.MainWindow, type)
            .Create(
                title: "Подтверждение",
                header: "Подтвердите действие",
                description: "Вы точно уверены??")
            .ShowWindow();
                break;
        }
    }

}
