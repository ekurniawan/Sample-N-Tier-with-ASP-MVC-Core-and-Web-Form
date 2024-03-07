using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

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
        if (TempData["message"] != null)
        {
            ViewData["message"] = TempData["message"];
        }

        var models = _categoryBLL.GetAll();
        return View(models);
    }

    public IActionResult Detail(int id)
    {
        var model = _categoryBLL.GetById(id);
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CategoryCreateDTO categoryCreate)
    {
        try
        {
            _categoryBLL.Insert(categoryCreate);
            //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
        }
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {

        return View();
    }

    [HttpPost]
    public IActionResult Edit(CategoryUpdateDTO categoryEdit)
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
