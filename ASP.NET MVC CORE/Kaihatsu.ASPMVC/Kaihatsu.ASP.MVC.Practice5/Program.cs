// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASP.MVC.Practice5;
using Kaihatsu.ASP.MVC.Practice5.Library;
using Kaihatsu.ASP.MVC.Practice5.Scaner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;




//IScaner scaner = new FileScaner("Scaner.txt");
//ScanerAdapter adapter = new ScanerAdapter(scaner);
//ScanerManager manager = new ScanerManager(adapter, FileLogger.Instacce("Log.txt"));
//ISaveStrategy strategy = new FileSaveStrategy();
//manager.ScanAndSave(strategy, "SaveStrategy.txt");

Startup startup = new Startup();
IServiceProvider services = Startup.ServiceProvider;
ScanerManager smanager = services.GetService<ScanerManager>();
smanager.ScanAndSave("SaveStrategy2.txt", "Scaner.txt");
