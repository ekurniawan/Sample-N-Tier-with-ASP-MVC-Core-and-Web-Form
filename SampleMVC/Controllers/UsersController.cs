using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using System.Text.Json;

namespace SampleMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBLL _userBLL;
        private readonly IRoleBLL _roleBLL;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserBLL userBLL, IRoleBLL roleBLL, ILogger<UsersController> logger)
        {
            _userBLL = userBLL;
            _roleBLL = roleBLL;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            _logger.LogInformation("User open index page");

            var users = _userBLL.GetAll();
            var listUsers = new SelectList(users, "Username", "Username");
            ViewBag.Users = listUsers;

            var roles = _roleBLL.GetAllRoles();
            var listRoles = new SelectList(roles, "RoleID", "RoleName");
            ViewBag.Roles = listRoles;

            var usersWithRoles = _userBLL.GetAllWithRoles();
            return View(usersWithRoles);
        }


        [HttpPost]
        public IActionResult Index(string Username, int RoleID)
        {
            try
            {
                _roleBLL.AddUserToRole(Username, RoleID);
                TempData["Message"] = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Role added successfully !</div>";
            }
            catch (Exception ex)
            {
                TempData["Message"] = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var userDto = _userBLL.LoginMVC(loginDTO);
                //simpan username ke session
                var userDtoSerialize = JsonSerializer.Serialize(userDto);
                HttpContext.Session.SetString("user", userDtoSerialize);

                TempData["Message"] = "Welcome " + userDto.Username;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
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



        public IActionResult Profile()
        {
            //var userWithRoles = _userBLL.GetUserWithRoles("ekurniawan");
            var usersWithRoles = _userBLL.GetAllWithRoles();
            return new JsonResult(usersWithRoles);
        }
    }
}
