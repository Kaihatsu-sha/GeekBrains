using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.ChainsOfResponsibility;

internal interface IProcessor
{
    public IProcessor AddBlock(IProcessorBlock processorBlock);
    public void Run(string context);
}
