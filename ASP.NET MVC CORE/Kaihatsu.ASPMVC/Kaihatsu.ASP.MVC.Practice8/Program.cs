using Kaihatsu.ASP.MVC.Practice8.Services;
using Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddControllersWithViews();//
services.AddLogging(app=> 
{
    app.ClearProviders();
    app.AddDebug();
    app.AddConsole();
});
services.AddSingleton<IEmployeesStore, InMemoryEmployeesStore>();

var app = builder.Build();//app builder конвеера для приложения. Паттерн цепочка обязанностей

#region Configure pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseStaticFiles();// Запросы до wwwroot
app.UseRouting(); // Использование маршрутов
app.MapControllerRoute(name: "default",pattern:"{controller=Home}/{action=Index}/{id?}"); // Объявленный маршрут

#endregion

app.Run();
