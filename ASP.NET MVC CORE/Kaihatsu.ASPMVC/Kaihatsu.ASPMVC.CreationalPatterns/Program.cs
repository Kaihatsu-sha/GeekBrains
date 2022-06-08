// See https://aka.ms/new-console-template for more information


using Kaihatsu.ASPMVC.CreationalPatterns;
using System.Diagnostics;

ILogger iLogger = ConsoleLogger.Logger;
iLogger.Log("Test console logger");
ConsoleLogger cLogger = ConsoleLogger.LoggerLazy;
cLogger.Log("Test console logger");
ILogger iLogger2 = ConsoleLogger.LoggerThread;
iLogger2.Log("Test console logger");
ILogger iLogger3 = ConsoleLogger.Logger;
iLogger3.Log("Test console logger");

if (ReferenceEquals(iLogger, cLogger))
    Console.WriteLine("iLogger == cLogger");
if (ReferenceEquals(iLogger, iLogger2))
    Console.WriteLine("iLogger == iLogger2");
if (ReferenceEquals(iLogger, iLogger3))
    Console.WriteLine("iLogger == iLogger3");
if (ReferenceEquals(iLogger2, iLogger3))
    Console.WriteLine("iLogger2 == iLogger3");

string pathA = "fileA.txt";
FileLogger fLoggerA = FileLogger.Create(pathA);
FileLogger fLoggerA2 = FileLogger.Create(pathA);
FileLogger fLoggerA3 = FileLogger.Create("fileA.txt");
FileLogger fLoggerB = FileLogger.Create("fileB.txt");

if (ReferenceEquals(fLoggerA, fLoggerA2))
    Console.WriteLine("fLoggerA == fLoggerA2");
if (ReferenceEquals(fLoggerA, fLoggerA3))
    Console.WriteLine("fLoggerA == fLoggerA3");
if (ReferenceEquals(fLoggerA2, fLoggerA3))
    Console.WriteLine("fLoggerA2 == fLoggerA3");
if (ReferenceEquals(fLoggerA, fLoggerB))
    Console.WriteLine("fLoggerA == fLoggerB");

IEnumerable<string> messages = Enumerable.Range(0, 100).Select(i => "Test message " + i);

LoggerFactory loggerFactory = new LoggerFactory();
loggerFactory.Type = LoggerFactory.LoggerType.Console;

// Какой смыслл передавать фабрику?
LoggerWorker worker = new LoggerWorker(loggerFactory, messages);

// Построитель
EMailBuilderFluent builder = new EMailBuilderFluent();
EMail eMail = builder
    .SetRecipient("support@gb.ru")
    .SetSubject("Lesson3")
    .SetTitle("Hi!")
    .SetBody("Great lesson, I'm impressed.")
    .SetSignature("Thank you for your attention!")
    .Build();

Console.ReadLine();


//public Process? Execute(string fileName, string args, bool useShellExecute = true)
//{
//    return Process.Start(new ProcessStartInfo(fileName, args){ UseShellExecute = useShellExecute });// Фабричный метод
//}

//public Process? ShowInExploree(string fullPathToFile)
//{
//    return Process.Start("explorer", $"/select,\"{fullPathToFile}\"");
//}
