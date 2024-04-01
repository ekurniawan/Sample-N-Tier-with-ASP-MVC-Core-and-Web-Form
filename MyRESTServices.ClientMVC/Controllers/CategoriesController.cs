using Microsoft.AspNetCore.Mvc;
using MyRESTServices.ClientMVC.Models;
using MyRESTServices.ClientMVC.Services;
using System.Text.Json;

namespace MyRESTServices.ClientMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _category;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategory category, ILogger<CategoriesController> logger)
        {
            _category = category;
            _logger = logger;
        }

        // GET: CategoriesController1
        public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
            {
                return RedirectToAction("Index", "Account");
            }
            _logger.LogInformation($"--------------------------> {HttpContext.Session.GetString("token")}");
            var token = JsonSerializer.Deserialize<UserWithTokenViewModel>(HttpContext.Session.GetString("token"));
            var model = await _category.GetAll(token.Token);
            return View(model);
        }

        // GET: CategoriesController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
