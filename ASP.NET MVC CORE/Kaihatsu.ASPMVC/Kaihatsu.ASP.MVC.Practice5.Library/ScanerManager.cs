using Kaihatsu.ASP.MVC.Practice5;
namespace Kaihatsu.ASP.MVC.Practice5.Library;


public class ScanerManager 
{
    private readonly Scaner _scaner;
    private readonly ILogger _logger;

    public ScanerManager(Scaner scaner, ILogger logger)
    {
        _scaner = scaner;
        _logger = logger;
    }

    public void ScanAndSave(ISaveStrategy strategy, string path)
    {
        if (!_scaner.IsReady)
            _logger.Error("Устройство не готово!");

        _logger.Info("Информация по устройству: " + _scaner.Info);
        
        strategy.Save(path, _scaner.Scanning());

        _logger.Info("Информация по устройству: " + _scaner.Info);
    }

    private void Loging()
    {
        _logger.Debug("Опрос статуса устройства" 
            +  (_scaner.IsReady ? "Готов к работе" : "Не готов") 
            + " Информация по устройству: " + _scaner.Info);
    }
}
