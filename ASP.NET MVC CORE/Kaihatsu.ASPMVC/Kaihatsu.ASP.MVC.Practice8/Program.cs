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

var app = builder.Build();//app builder �������� ��� ����������. ������� ������� ������������

#region Configure pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseStaticFiles();// ������� �� wwwroot
app.UseRouting(); // ������������� ���������
app.MapControllerRoute(name: "default",pattern:"{controller=Home}/{action=Index}/{id?}"); // ����������� �������

#endregion

app.Run();
