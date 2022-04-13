using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.ChainsOfResponsibility;

internal class Processor
{
    private readonly List<IProcessorBlock> _processors = new();

    public Processor AddBlock(IProcessorBlock processorBlock)
    {
        _processors.Add(processorBlock);
        return this;
    }

    public void Run(string context)
    {
        // Визитер?!
       foreach (IProcessorBlock block in _processors)
        {
            bool rezult = block.Process(context.ToLower());
            if (rezult)
                throw new ArgumentException(nameof(context) + " Не прошел политику безопасности. Политика:");// Вывод типа + typeof(block).Name);
        }
    }
}
