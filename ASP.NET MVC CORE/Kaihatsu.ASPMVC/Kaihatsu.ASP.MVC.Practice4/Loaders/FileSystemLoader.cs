using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Loaders;

internal class FileSystemLoader : Loader
{
    public override string LoadFrom(string path)
    {
        if(!File.Exists(path))
            throw new ArgumentException(nameof(path));

        string loadedData = string.Empty;

        using (StreamReader streamReader = new StreamReader(path))
        {
            loadedData = streamReader.ReadToEnd();
        }

        return loadedData;
    }
}
