using Microsoft.AspNetCore.Mvc;
using MyRESTServices.ClientMVC.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MyRESTServices.ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //check session
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
            {
                ViewBag.Message = "Token empty";
                return View();
            }

            var token = JsonSerializer.Deserialize<UserWithTokenViewModel>(HttpContext.Session.GetString("token"));
            ViewBag.Username = token.Username;
            ViewBag.Token = token.Token;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
