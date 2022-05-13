using System.Diagnostics;

namespace Kaihatsu.ASP.MVC.Practice7.Infrastructure;

internal static class FileInfoExtension
{
    public static Process? Execute(this FileInfo file, bool UseShellExecute = true)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo(file.FullName) { UseShellExecute = UseShellExecute };
        
        return Process.Start(processStartInfo);
    }
}
