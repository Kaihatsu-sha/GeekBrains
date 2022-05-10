using Kaihatsu.ASP.MVC.Practice5.Scaner;

namespace Kaihatsu.ASP.MVC.Practice5;

internal class ScanerAdapter : Kaihatsu.ASP.MVC.Practice5.Library.Scaner
{
    private readonly IScaner _scaner;
    public ScanerAdapter(IScaner scaner)
    {
        _scaner = scaner;
    }

    public override bool IsReady => _scaner.IsReady;

    public override string Info => $" время:{_scaner.SystemResource.Time}, загрузка ЦП: {_scaner.SystemResource.ProcessorLoad}, загрузка ОЗУ: {_scaner.SystemResource.MemoryLoad} ";

    public override byte[] Scanning(string path)
    {
        return _scaner.Scanning(path);
    }
}
