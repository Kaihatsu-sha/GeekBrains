namespace Kaihatsu.ASP.MVC.Practice5.Scaner;

public interface IScaner
{
    public bool IsReady { get; }
    public SystemResource SystemResource { get; }
    public byte[] Scanning();
}
