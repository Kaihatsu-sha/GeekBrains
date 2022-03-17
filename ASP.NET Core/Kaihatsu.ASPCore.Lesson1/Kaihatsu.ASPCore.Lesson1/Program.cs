using Kaihatsu.ASPCore.Lesson1;

Console.WriteLine("Main is start");
Worker worker = new Worker();
await worker.Start();
Console.WriteLine("Main is end");