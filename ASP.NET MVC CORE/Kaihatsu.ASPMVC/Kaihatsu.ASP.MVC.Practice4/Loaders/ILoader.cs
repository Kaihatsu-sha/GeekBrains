using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Loaders;

internal interface ILoader
{
    public string LoadFrom(string path);
}
