using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.Strategy;

internal interface IStrategy
{
    public void SafeTo(string path, string value);
}
