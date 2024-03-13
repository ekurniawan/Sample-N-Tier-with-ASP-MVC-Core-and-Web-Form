using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

namespace SampleMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBLL _userBLL;
        public UsersController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //register user baru
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserCreateDTO userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _userBLL.Insert(userCreateDto);
                ViewBag.Message = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Registration process successfully !</div>";

            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
            }

            return View();
        }
    }
}
