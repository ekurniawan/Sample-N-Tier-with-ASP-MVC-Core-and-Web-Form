using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.Helpers;
using SampleMVC.Models;
using SampleMVC.Services;
using System.Text.Json;

namespace SampleMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryBLL _categoryBLL;
    private readonly ICategoryServices _categoryServices;
    private UserDTO user = null;
    public CategoriesController(ICategoryBLL categoryBLL, ICategoryServices categoryServices)
    {
        _categoryBLL = categoryBLL;
        _categoryServices = categoryServices;

    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 5, string search = "", string act = "")
    {

        if (HttpContext.Session.GetString("user") == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
            return RedirectToAction("Login", "Users");
        }
        user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
        //pengecekan session username
        if (Auth.CheckRole("reader,admin,contributor", user.Roles.ToList()) == false)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
            return RedirectToAction("Index", "Home");
        }


        if (TempData["message"] != null)
        {
            ViewData["message"] = TempData["message"];
        }

        ViewData["search"] = search;
        var models = _categoryBLL.GetWithPaging(pageNumber, pageSize, search);
        var maxsize = _categoryBLL.GetCountCategories(search);
        //return Content($"{pageNumber} - {pageSize} - {search} - {act}");

        if (act == "next")
        {
            if (pageNumber * pageSize < maxsize)
            {
                pageNumber += 1;
            }
            ViewData["pageNumber"] = pageNumber;
        }
        else if (act == "prev")
        {
            if (pageNumber > 1)
            {
                pageNumber -= 1;
            }
            ViewData["pageNumber"] = pageNumber;
        }
        else
        {
            ViewData["pageNumber"] = 2;
        }

        ViewData["pageSize"] = pageSize;
        //ViewData["action"] = action;


        return View(models);
    }

    public async Task<IActionResult> GetFromServices()
    {
        var categories = await _categoryServices.GetAll();
        List<Category> categoriesList = new List<Category>();
        foreach (var category in categories)
        {
            categoriesList.Add(new Category
            {
                categoryID = category.CategoryID,
                categoryName = category.CategoryName
            });
        }
        return View(categoriesList);
    }


    public IActionResult Detail(int id)
    {
        if (HttpContext.Session.GetString("user") == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
            return RedirectToAction("Login", "Users");
        }
        user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));

        //pengecekan session username
        if (Auth.CheckRole("reader,admin,contributor", user.Roles.ToList()) == false)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
            return RedirectToAction("Index", "Home");
        }

        var model = _categoryBLL.GetById(id);
        return View(model);
    }

    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("user") == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
            return RedirectToAction("Login", "Users");
        }
        user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));

        //pengecekan session username
        if (Auth.CheckRole("admin,contributor", user.Roles.ToList()) == false)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
            return RedirectToAction("Index", "Home");
        }

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
        if (HttpContext.Session.GetString("user") == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
            return RedirectToAction("Login", "Users");
        }
        user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));

        //pengecekan session username
        if (Auth.CheckRole("admin,contributor", user.Roles.ToList()) == false)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
            return RedirectToAction("Index", "Home");
        }

        var model = _categoryBLL.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, CategoryUpdateDTO categoryEdit)
    {
        try
        {
            _categoryBLL.Update(categoryEdit);
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            return View(categoryEdit);
        }
        return RedirectToAction("Index");
    }



    public IActionResult Delete(int id)
    {
        if (HttpContext.Session.GetString("user") == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
            return RedirectToAction("Login", "Users");
        }
        user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));

        //pengecekan session username
        if (Auth.CheckRole("admin,contributor", user.Roles.ToList()) == false)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
            return RedirectToAction("Login", "Users");
        }

        var model = _categoryBLL.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int id, CategoryDTO category)
    {
        try
        {
            _categoryBLL.Delete(id);
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Delete Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            return View(category);
        }
        return RedirectToAction("Index");
    }

    public IActionResult DisplayDropdownList()
    {
        var categories = _categoryBLL.GetAll();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult DisplayDropdownList(string CategoryID)
    {
        ViewBag.CategoryID = CategoryID;
        ViewBag.Message = $"You selected {CategoryID}";

        ViewBag.Categories = _categoryBLL.GetAll();

        return View();
    }

}
