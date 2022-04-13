using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.WPF;

internal class FibonacceThread
{
    public readonly Thread _thread;
    private int _timeout;
    private volatile bool _isRun = false;
    private int _startNumber = 1;
    private readonly Action<long> _action;

    public int Timeout 
    { 
        get { return _timeout; } 
        set 
        { 
            if(_timeout > 0)
                _timeout = value; 
        }
    }

    public bool IsRunning
    {
        get { return _isRun; }
        set { _isRun = value; }
    }

    public FibonacceThread(Action<long> addInTextBox,int timeout = 1_000)
    {
        _timeout = timeout;
        _action = addInTextBox;

        _thread = new Thread(RunFibonacci);
        _thread.Name = "FibonacceThread";
        _thread.IsBackground = true;
        _thread.Priority = ThreadPriority.Lowest;
        int threadId = Environment.CurrentManagedThreadId;
    }

    public void Run()
    {
        _isRun = true;

        _thread.Start();
    }

    public bool StopJoin()
    {
        _isRun = false;
        bool isJoin = _thread.Join(_timeout + 250);
        return isJoin;
    }

    public void StopInterrupt()
    {
        Thread.CurrentThread.Interrupt();
    }

    private void RunFibonacci()
    {
        while (_isRun)
        {
            long value = Fibonacce.GetNumber(_startNumber);
            _action?.Invoke(value);
            Thread.Sleep(_timeout);

            _startNumber++;
        }
    }
}
