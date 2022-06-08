using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.Strategy;

internal class FileSystemOverwritten : IStrategy
{
    public void SafeTo(string path, string value)
    {
        if(!File.Exists(path))
            throw new ArgumentException(nameof(path));

        File.WriteAllText(path, value);
    }
}
