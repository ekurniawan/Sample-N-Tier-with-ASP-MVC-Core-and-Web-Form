using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Models;

namespace SampleMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryBLL _categoryBLL;
    public CategoriesController(ICategoryBLL categoryBLL)
    {
        _categoryBLL = categoryBLL;
    }

    public IActionResult Index()
    {
        var models = _categoryBLL.GetAll();
        return View(models);
    }

    public IActionResult Detail(int id)
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {

        return View();
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Search(string search)
    {

        return View("Index");

    }

    public IActionResult Delete(int id)
    {

        return RedirectToAction("Index");
    }


}
