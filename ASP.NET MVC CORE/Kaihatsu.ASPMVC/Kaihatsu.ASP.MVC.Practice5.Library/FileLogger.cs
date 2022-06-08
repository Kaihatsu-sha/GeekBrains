using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice5.Library;

public class FileLogger : ILogger
{
    private readonly FileInfo _file;
    private static ILogger _instance;

    // Фабричный метод
    public static ILogger Instacce(string path) => _instance ??= new FileLogger(path);

    private FileLogger(string path)
    {
        if (!File.Exists(path))
        {
            _file = new FileInfo(path);
            _file.Create();
        }
        else
        {
            _file = new FileInfo(path);

        }
    }

    public void Debug(string message)
    {
        using (StreamWriter stream = _file.AppendText())
        {
            stream.WriteLine($"[D][{DateTime.Now:HH:mm:ss}]{message}");
        }
    }

    public void Error(string message)
    {
        using (StreamWriter stream = _file.AppendText())
        {
            stream.WriteLine($"[E][{DateTime.Now:HH:mm:ss}]{message}");
        }
    }

    public void Info(string message)
    {
        using (StreamWriter stream = _file.AppendText())
        {
            stream.WriteLine($"[I][{DateTime.Now:HH:mm:ss}]{message}");
        }
    }
}
