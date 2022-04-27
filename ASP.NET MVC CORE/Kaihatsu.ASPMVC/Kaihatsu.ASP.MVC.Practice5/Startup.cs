using Kaihatsu.ASP.MVC.Practice5;
using Kaihatsu.ASP.MVC.Practice5.Library;
using Kaihatsu.ASP.MVC.Practice5.Scaner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kaihatsu.ASP.MVC.Practice5;

internal class Startup
{
    
    public Startup() 
    {
        CreateHostBuilder(Environment.GetCommandLineArgs())
            .Build()
            .Start();
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
    }
}
