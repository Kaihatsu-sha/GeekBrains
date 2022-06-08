using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.Strategy;

internal class Scaner
{
    private readonly IStrategy _strategy;


    public Scaner(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Scan()
    {
        string scannedText = "scannedTextscannedTextscannedTextscannedTextscannedTextscannedText";

        _strategy.SafeTo("file1.txt",scannedText);
    }
}
