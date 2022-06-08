namespace Kaihatsu.ASP.MVC.Practice5.Library;


public abstract class Scaner
{
    public abstract bool IsReady { get; }
    public abstract string Info { get; }
    public abstract byte[] Scanning();
}
