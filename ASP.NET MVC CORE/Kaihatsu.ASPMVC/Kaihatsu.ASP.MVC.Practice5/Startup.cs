using Kaihatsu.ASP.MVC.Practice5;
using Kaihatsu.ASP.MVC.Practice5.Library;
using Kaihatsu.ASP.MVC.Practice5.Scaner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kaihatsu.ASP.MVC.Practice5;

internal class Startup
{
    public static IServiceProvider ServiceProvider { get; private set; }
    
    public Startup() 
    {
        IHost host = CreateHostBuilder(Environment.GetCommandLineArgs())
            .Build();
        host.Start();
        ServiceProvider = host.Services;
    }

    private IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
           //.ConfigureHostConfiguration(opt => opt.AddJsonFile("appsettings.json"))
           //.ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json"))
           .ConfigureLogging(configure =>
           {
               configure.ClearProviders();
               configure.AddDebug();
               configure.AddConsole();
           })
           .ConfigureServices(ConfigureServices);
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<Kaihatsu.ASP.MVC.Practice5.Library.ILogger, FileLogger>();

        services.AddTransient<IScaner, FileScaner>();        
        services.AddTransient<Kaihatsu.ASP.MVC.Practice5.Library.Scaner, ScanerAdapter>();
        services.AddTransient<ISaveStrategy, FileSaveStrategy>();
        services.AddTransient<ScanerManager>();        
    }
}