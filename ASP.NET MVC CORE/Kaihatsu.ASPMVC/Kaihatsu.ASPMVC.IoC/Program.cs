// See https://aka.ms/new-console-template for more information

using Kaihatsu.ASPMVC.DAL.Context;
using Kaihatsu.ASPMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

IServiceCollection services = new ServiceCollection();
services.AddDbContext<OrdersDB>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=OrdersDB;Username=postgres;Password=postgres;"));

ServiceProvider serviceProvider = services.BuildServiceProvider();
OrdersDB serviceOrdersDB = serviceProvider.GetRequiredService<OrdersDB>();
foreach (Buyer buyer in serviceOrdersDB.Buyers)
{
    Console.WriteLine($"[{buyer.Id}] : {buyer.LastName} NAME {buyer.Patronymic} {buyer.Age}");
}
