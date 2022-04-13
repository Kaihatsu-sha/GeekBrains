// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASPMVC.CustomThreadPool;

Console.WriteLine("Hello, World!");

Random random = new Random();
CustomThreadPool pool = new CustomThreadPool(3);
pool.AddTask(PrintToConsole);
pool.AddTask(PrintToConsole);
pool.AddTask(PrintToConsole);
pool.AddTask(PrintToConsole);
pool.AddTask(PrintToConsole);
pool.AddTask(PrintToConsole);

Console.ReadLine();
pool.Stop();
Console.ReadLine();

void PrintToConsole()
{
    int timeout = random.Next(1_000, 10_000);
    Thread.Sleep(timeout);
    Console.WriteLine($"[{Environment.CurrentManagedThreadId}] executing method in Main for millisec {timeout}");
    Thread.Sleep(timeout / 2);
}