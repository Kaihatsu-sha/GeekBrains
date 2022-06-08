using Kaihatsu.ASP.MVC.Practice5;
namespace Kaihatsu.ASP.MVC.Practice5.Library;


public class ScanerManager 
{
    private readonly Scaner _scaner;
    private readonly ILogger _logger;
    private readonly ISaveStrategy _saveStrategy;

    public ScanerManager(Scaner scaner, ILogger logger, ISaveStrategy strategy)
    {
        _scaner = scaner;
        _logger = logger;
        _saveStrategy = strategy;
    }

    public void ScanAndSave(string savePath, string ScanningPath)
    {
        if (!_scaner.IsReady)
            _logger.Error("Устройство не готово!");

        _logger.Info("Информация по устройству: " + _scaner.Info);

        _saveStrategy.Save(savePath, _scaner.Scanning(ScanningPath));

        _logger.Info("Информация по устройству: " + _scaner.Info);
    }

    private void Loging()
    {
        _logger.Debug("Опрос статуса устройства" 
            +  (_scaner.IsReady ? "Готов к работе" : "Не готов") 
            + " Информация по устройству: " + _scaner.Info);
    }
}
