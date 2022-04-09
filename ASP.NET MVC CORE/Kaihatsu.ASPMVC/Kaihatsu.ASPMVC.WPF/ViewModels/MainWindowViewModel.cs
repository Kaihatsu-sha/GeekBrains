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

    private LambdaCommand _errorWindow;
    private LambdaCommand _confirmWindow;
    private LambdaCommand _informationWindow;

    public LambdaCommand ShowErrorWindow
    {
        get
        {
            return _errorWindow ??= new LambdaCommand(ExecuteError);
        }
    }

    public LambdaCommand ShowConfirmWindow
    {
        get
        {
            return _confirmWindow ??= new LambdaCommand(ExecuteConfirm);
        }
    }

    public LambdaCommand ShowInformationWindow
    {
        get
        {
            return _informationWindow ??= new LambdaCommand(ExecuteInfo);
        }
    }

    private void ExecuteInfo(object? parameter)
    {
        WindowsFactory
            .GetFactory(App.Current.MainWindow, WindowType.Information)
            .Create(
                title: "Информация",
                header: "Внимание!!!",
                description: "Ставки на спорт")
            .ShowWindow();
    }

    private void ExecuteError(object? parameter)
    {
        WindowsFactory
            .GetFactory(App.Current.MainWindow, WindowType.Information)
            .Create(
                title: "Ошибка",
                header: "Произошла ошибка",
                description: "NullReferenceException")
            .ShowWindow();
    }

    private void ExecuteConfirm(object? parameter)
    {
        WindowsFactory
            .GetFactory(App.Current.MainWindow, WindowType.Information)
            .Create(
                title: "Подтверждение",
                header: "Подтвердите действие",
                description: "Вы точно уверены??")
            .ShowWindow();
    }

}
