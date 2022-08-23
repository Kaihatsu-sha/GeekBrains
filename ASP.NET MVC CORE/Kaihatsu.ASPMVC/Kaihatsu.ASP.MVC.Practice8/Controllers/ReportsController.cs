using Kaihatsu.ASP.MVC.Practice8.Models;
using Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RazorEngine;
using RazorEngine.Templating;

namespace Kaihatsu.ASP.MVC.Practice8.Controllers;

public class ReportsController : Controller
{
    private readonly IEmployeesStore _store;
    private string _pathToTemplatesFolder;
    public ReportsController(IEmployeesStore store)
    {
        _store = store;
        _pathToTemplatesFolder = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Templates\\";
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create(string name)
    {
        string templateReport = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(System.IO.Path.Combine(_pathToTemplatesFolder, name)));
        IEnumerable<EmployeeModel> employeesModel = _store.Get();
        string compiledReport = Engine.Razor.RunCompile(templateReport, "report", null, new 
        {
            Title = "Все сотрудники",
            Employees = employeesModel
        });

        string contentType = "application/pdf";

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(compiledReport);

        return File(buffer, contentType, "AllEmployeesReport.html");
    }

    [HttpGet]
    public IActionResult Show(string name)
    {
        string templateReport = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(System.IO.Path.Combine(_pathToTemplatesFolder, name)));

        string compiledReport = Engine.Razor.RunCompile(templateReport, "report", null, new
        {
            Title = "Все сотрудники",
            Employees = new List<EmployeeModel>
            { 
                new EmployeeModel{ Id = 0, LastName="Пупкин", FirstName="Василий", Patronymic="Фёдорович", Birthday = DateTime.Now.AddYears(-22)},
                new EmployeeModel{ Id = 1, LastName="Пупкин", FirstName="Фёдор", Patronymic="Петрович", Birthday = DateTime.Now.AddYears(-45)}
            }
        });
        string contentType = "application/pdf";

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(compiledReport);

        return File(buffer, contentType, "AllEmployeesReport.html");
    }
}
