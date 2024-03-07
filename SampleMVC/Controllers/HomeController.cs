using Microsoft.AspNetCore.Mvc;
namespace SampleMVC.Controllers;

public class HomeController : Controller
{
    // Home/Index
    public IActionResult Index()
    {
        ViewData["Title"] = "Home Page";
        return View();
    }

    [Route("/Hello/ASP")]
    public IActionResult HelloASP()
    {
        return Content("Hello ASP.NET Core MVC!");
    }

    // Home/About
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return Content("This is the Contact action method...");
    }
}
