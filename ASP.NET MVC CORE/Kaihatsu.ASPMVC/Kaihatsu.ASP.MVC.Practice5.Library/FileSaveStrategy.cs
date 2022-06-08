using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice5.Library;

public class FileSaveStrategy : ISaveStrategy
{
    public void Save(string path, byte[] data)
    {
        if (!File.Exists(path))
        {
            CreateFile(path, data);
        }

        WriteInFile(path,data);
    }

    private void CreateFile(string path, byte[] data)
    {
        using (FileStream stream = File.Create(path))
        {
            stream.Write(data, 0, data.Length);
        }
    }

    private void WriteInFile(string path, byte[] data)
    {
        using (FileStream stream = File.OpenWrite(path))
        {
            stream.Write(data, 0, data.Length);
        }
    }
}
