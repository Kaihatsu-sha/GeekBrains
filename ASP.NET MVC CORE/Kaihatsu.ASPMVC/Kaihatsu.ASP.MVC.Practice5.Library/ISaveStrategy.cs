using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice5.Library;

public interface ISaveStrategy
{
    public void Save(string path, byte[] data);
}
