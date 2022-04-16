// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASP.MVC.Practice5;
using Kaihatsu.ASP.MVC.Practice5.Library;
using Kaihatsu.ASP.MVC.Practice5.Scaner;


IScaner scaner = new FileScaner("Scaner.txt");
ScanerAdapter adapter = new ScanerAdapter(scaner);
ScanerManager manager = new ScanerManager(adapter, FileLogger.Instacce("Log.txt"));
ISaveStrategy strategy = new FileSaveStrategy();
manager.ScanAndSave(strategy, "SaveStrategy.txt");

