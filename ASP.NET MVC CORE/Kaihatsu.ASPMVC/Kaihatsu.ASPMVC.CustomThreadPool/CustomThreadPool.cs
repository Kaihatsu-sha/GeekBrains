using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CustomThreadPool;

internal class CustomThreadPool
{
    private readonly Queue<Thread> _threads;
    private readonly Thread _current;
    private readonly Queue<CustomTask> _queue;
    private int _taskСounter;
    private AutoResetEvent _autoResetEvent;
    private readonly object _lock;
    private bool _isRunning = true;

    public CustomThreadPool(int threadCount = 2)
    {
        if (threadCount <= 0 || threadCount > 4)
            throw new ArgumentException(nameof(threadCount));

        _threads = new Queue<Thread>();
        _queue = new Queue<CustomTask>();
        _autoResetEvent = new AutoResetEvent(false);

        for (int i = 0; i < threadCount; i++)
        {
            Thread newThread = new Thread(ExecuteNext);
            newThread.Name = $"CustomThreadPoll-{i}";
            newThread.IsBackground = true;
            newThread.Priority = ThreadPriority.Lowest;
            newThread.Start();
            Console.WriteLine($"[{newThread.ManagedThreadId}]Thread started");
            _threads.Enqueue(newThread);
        }
        _current = new Thread(Run);
        _current.Name = "WaitNewTask";
        _current.IsBackground = true;
        _current.Priority = ThreadPriority.Normal;
        _current.Start();

        _lock = new object();
    }

    public void AddTask(Action task)
    {
        _taskСounter++;
        lock (_lock)
        {
            _queue.Enqueue(new CustomTask(task, _taskСounter));
            Console.WriteLine($"[{Environment.CurrentManagedThreadId}] add task");
        }
    }

    private void Run()
    {
        while (_isRunning)
        {
            if (_queue.Count > 0 && _threads.Count > 0)
            {
                Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread get count {_queue.Count}");
                Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread set event");
                _autoResetEvent.Set();
            }
            Thread.Sleep(250);
        }
    }

    private void ExecuteNext()
    {
        while (_isRunning)
        {
            Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread wait");
            _autoResetEvent.WaitOne();
            Thread worker = _threads.Dequeue();
            Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread go to work");
            CustomTask task = _queue.Dequeue();

            Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread get next TaskId {task.Id}");
            task.Action?.Invoke();

            Console.WriteLine($"[{Environment.CurrentManagedThreadId}]Thread Task complited {task.Id}");
            _threads.Enqueue(worker);
        }
    }

    public void Stop()
    {
        _isRunning = false;
        Console.WriteLine("STOP id {0}", Environment.CurrentManagedThreadId);

        _current.Join(1_000);
        while (_threads.Count > 0)
        {
            Thread threadFromPool = _threads.Dequeue();
            threadFromPool.Join(1_000);
        }
    }

    ~CustomThreadPool()
    {
        _isRunning = false;

        _current.Join(1_000);
        while (_threads.Count > 0)
        {
            Thread threadFromPool = _threads.Dequeue();
            threadFromPool.Join(1_000);
        }
    }

}
