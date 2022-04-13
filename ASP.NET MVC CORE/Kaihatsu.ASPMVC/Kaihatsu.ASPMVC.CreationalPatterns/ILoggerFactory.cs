using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

internal interface ILoggerFactory
{
    public ILogger Create();
}
