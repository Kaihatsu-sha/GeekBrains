using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns;

internal class SuperTest
{
    public static void Start()
    {
        bool isRun = true;
        ExecMethod method = new ExecMethod();
        
        for (bool inCycle = isRun; inCycle; inCycle &= isRun)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss:ffff}] START cycle");
           
            method.Method();
            Thread.Sleep(100);

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss:ffff}] END cycle");
        }
    }
}

internal class ExecMethod
{
    public void Method(int delay = 10)
    {
        Stopwatch watch = Stopwatch.StartNew();
        Stopwatch  stopwath = Stopwatch.StartNew();
        EceuteMethod();
        stopwath.Stop();

        long waitTime = (delay * 1000) - stopwath.ElapsedMilliseconds;
        stopwath.Reset();
        while(waitTime > 0) 
        {
            Thread.Sleep(50);
            waitTime -= 50;
        }
        watch.Stop();
        Console.WriteLine($"[{watch.ElapsedMilliseconds}] total");
    }

    private void EceuteMethod()
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss:ffff}] START");
        Thread.Sleep(2000);
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss:ffff}] END");
    }
}