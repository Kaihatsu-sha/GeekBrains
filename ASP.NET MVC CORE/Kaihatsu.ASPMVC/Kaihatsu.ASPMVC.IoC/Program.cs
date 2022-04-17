// See https://aka.ms/new-console-template for more information

using Kaihatsu.ASPMVC.DAL.Context;
using Kaihatsu.ASPMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHost _Host = CreateHostBuilder(Environment.GetCommandLineArgs())
    .Build();

IServiceProvider _serviceProvider = _Host.Services;

bool isRunning = true;
_Host.Start();
{
    Console.WriteLine("Start");   
    using (OrdersDB serviceDB = _serviceProvider.GetRequiredService<OrdersDB>())
    {
        serviceDB.Database.Migrate();
        foreach (Buyer buyer in serviceDB.Buyers)
        {
            Console.WriteLine($"[{buyer.Id}] : {buyer.LastName} NAME {buyer.Patronymic} {buyer.Age}");
        }
    }
}
_Host.StopAsync();


//UseDB();
//UseDBFromServices();

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
       .ConfigureHostConfiguration(opt => opt.AddJsonFile("appsettings.json"))
       .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json"))
       .ConfigureLogging(configure =>
           {
               configure.ClearProviders();
               configure.AddDebug();
               configure.AddConsole();
           })
       .ConfigureServices(ConfigureServices);
}

void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddDbContext<OrdersDB>(options =>
        options.UseNpgsql(context.Configuration.GetConnectionString("Npgsql")));
}

void UseDB()
{
    // Используем ДБ без контейнера сервисов
    var dbBuilder = new DbContextOptionsBuilder<OrdersDB>()
        .UseNpgsql("Host=localhost;Port=5432;Database=OrdersDB;Username=postgres;Password=postgres;");

    using (var db = new OrdersDB(dbBuilder.Options))
    {
        //db.Database.EnsureCreated();

        if (db.Buyers.Any())
        {
            db.Buyers.Add(new Buyer() { Age = 18, LastName = "Sidorov", Patronymic = "Vladimirovich" });
            db.Buyers.Add(new Buyer() { Age = 29, LastName = "Sidorov", Patronymic = "Mixailovich" });
            db.Buyers.Add(new Buyer() { Age = 21, LastName = "Pushnov", Patronymic = "Vladimirovich" });

            db.SaveChanges();
        }
    }
}

void UseDBFromServices()
{
    IServiceCollection services = new ServiceCollection();
    services.AddDbContext<OrdersDB>(options =>
        options.UseNpgsql("Host=localhost;Port=5432;Database=OrdersDB;Username=postgres;Password=postgres;"));

    ServiceProvider serviceProvider = services.BuildServiceProvider();
    OrdersDB serviceOrdersDB = serviceProvider.GetRequiredService<OrdersDB>();
    foreach (Buyer buyer in serviceOrdersDB.Buyers)
    {
        Console.WriteLine($"[{buyer.Id}] : {buyer.LastName} NAME {buyer.Patronymic} {buyer.Age}");
    }
}
