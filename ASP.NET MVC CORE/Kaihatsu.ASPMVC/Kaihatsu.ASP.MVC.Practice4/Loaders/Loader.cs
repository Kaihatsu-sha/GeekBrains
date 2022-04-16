using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Loaders;

// Фабричный метод
internal abstract class Loader : ILoader
{
    public static ILoader FileSystemInstance => new FileSystemLoader();

    public abstract string LoadFrom(string path);
}
