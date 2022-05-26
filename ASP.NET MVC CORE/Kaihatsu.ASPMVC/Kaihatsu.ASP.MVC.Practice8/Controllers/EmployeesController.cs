using Kaihatsu.ASP.MVC.Practice8.Models;
using Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;
using Kaihatsu.ASP.MVC.Practice8.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kaihatsu.ASP.MVC.Practice8.Controllers;

public class EmployeesController : Controller
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IEmployeesStore _employeesStore;
    public EmployeesController(ILogger<EmployeesController> logger, IEmployeesStore store)
    {
        _logger = logger;
        _employeesStore = store;
        ViewData["Title"] = "Сотрудники";
    }

    public IActionResult Index()
    {
        var employees = _employeesStore.Get();
        return View(employees);
    }

    public IActionResult Details(int id)
    {
        var employee = _employeesStore.GetById(id);
        if(employee is null)
            return NotFound();

        return View(new EmployeeViewModel 
        { 
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            Birthday = employee.Birthday
        });
    }

    public IActionResult Edit(int? id)
    {
        if (id is null)
        {
            return View(new EmployeeViewModel());
        }

        var employee = _employeesStore.GetById(id.Value);
        if (employee is null)
            return NotFound();

        return View(new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            Birthday = employee.Birthday
        });
    }

    [HttpPost]
    public IActionResult Edit(EmployeeViewModel model)
    {
        var employee = new EmployeeModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Birthday = model.Birthday
        };

        if (employee.Id == 0)
        {
            int id = _employeesStore.Add(employee);
            return RedirectToAction("Details", new { id });
        }

        bool success = _employeesStore.Update(employee);
        if(!success)
            return NotFound();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var employee = _employeesStore.GetById(id);
        if (employee is null)
            return NotFound();

        return View(new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            Birthday = employee.Birthday
        });
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        bool success = _employeesStore.Remove(id);
        if (!success)
            return NotFound();

        return RedirectToAction("Index");
    }

    public IActionResult Create() => View("Edit");
}
