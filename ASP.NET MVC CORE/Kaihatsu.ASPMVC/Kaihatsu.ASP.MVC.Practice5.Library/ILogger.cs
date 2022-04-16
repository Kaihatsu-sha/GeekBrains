using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice5.Library;

public interface ILogger
{
    public void Debug(string message);
    public void Info(string message);
    public void Error(string message);
}
