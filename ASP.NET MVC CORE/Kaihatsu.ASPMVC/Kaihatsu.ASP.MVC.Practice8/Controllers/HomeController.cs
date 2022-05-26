using Microsoft.AspNetCore.Mvc;
using Kaihatsu.ASP.MVC.Practice8.Models;
using System.Diagnostics;
using Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;

namespace Kaihatsu.ASP.MVC.Practice8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        ViewData["Title"] = "Главная";
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
