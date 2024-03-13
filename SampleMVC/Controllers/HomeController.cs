using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.DTOs;
using System.Text.Json;
namespace SampleMVC.Controllers;

public class HomeController : Controller
{
    // Home/Index
    public IActionResult Index()
    {
        //check if session not null
        if (HttpContext.Session.GetString("user") != null)
        {
            var userDto = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            ViewBag.Message = $"Welcome {userDto.FirstName} {userDto.LastName}";
        }

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

    //action method for uploading file
    public IActionResult UploadFilePics()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadFilePics(IFormFile file)
    {
        if (file != null)
        {
            if (Helper.IsImageFile(file.FileName))
            {
                //random file name based on GUID
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pics", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                ViewBag.Message = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>File uploaded successfully !</div>";
            }
            else
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>File is not an image file !</div>";
            }
        }
        return View();
    }
}
