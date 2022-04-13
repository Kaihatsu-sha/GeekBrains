using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.Visitor;

internal class VisitorExample
{
    public void Run()
    {
        string path = @"..\..\..\..";
        FileSystemVisitor visitor = new FileSystemVisitor();
        
        DirectoryInfo dir = new DirectoryInfo(path);
        visitor.Visit(dir);

        Console.WriteLine(visitor.Count);
    }
}
