using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using SampleMVC.Models;
using SampleMVC.Services;
using SampleMVC.ViewModels;
namespace SampleMVC.Controllers;


[Authorize(Roles = "admin,contributor")]
public class CategoriesController : Controller
{
    private readonly ICategoryServices _categoryServices;
    //private readonly IValidator<CategoryCreateDTO> _validatorCategoryCreateDTO;

    //private UserDTO user = null;
    public CategoriesController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
        //_validatorCategoryCreateDTO = validatorCategoryCreateDTO;
    }


    public IActionResult Index(int pageNumber = 1, int pageSize = 5, string search = "", string act = "")
    {

        /*if (HttpContext.Session.GetString("user") == null)
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
        }*/


        if (TempData["message"] != null)
        {
            ViewData["message"] = TempData["message"];
        }

        ViewData["search"] = search;

        CategoriesViewModel categoriesViewModel = new CategoriesViewModel()
        {
            Categories = _categoryBLL.GetWithPaging(pageNumber, pageSize, search)
        };

        //var models = _categoryBLL.GetWithPaging(pageNumber, pageSize, search);
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


        return View(categoriesViewModel);
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
        /*if (HttpContext.Session.GetString("user") == null)
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
        }*/

        var model = _categoryServices.GetById(id);
        return View(model);
    }

    [Authorize]
    public IActionResult Create()
    {

        //pengecekan session username dan role
        /*if (HttpContext.Session.GetString("user") == null)
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
        }*/

        //return View();

        return PartialView("_CreateCategoryPartial");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create(SampleMVC.ViewModels.CategoriesViewModel categoriesViewModel)
    {
        /*var result = _validatorCategoryCreateDTO.Validate(categoriesViewModel.CategoryCreateDTO);

        if (!result.IsValid)
        {
            //foreach (var failure in result.Errors)
            //{
            //    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //}
            result.AddToModelState(ModelState);
            //categoriesViewModel.Categories = _categoryBLL.GetWithPaging(1, 5, "");
            return View("Index", categoriesViewModel);
        }*/

        try
        {
            _categoryServices.Insert(categoriesViewModel.CategoryCreateDTO);
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

    [Authorize]
    public IActionResult Edit(int id)
    {
        /*if (HttpContext.Session.GetString("user") == null)
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
        }*/

        var model = _categoryServices.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Edit(int id, CategoryUpdateDTO categoryEdit)
    {
        try
        {
            _categoryServices.Update(id, categoryEdit);
            TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
        }
        catch (Exception ex)
        {
            ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            return View(categoryEdit);
        }
        return RedirectToAction("Index");
    }


    [Authorize]
    public IActionResult Delete(int id)
    {
        /*if (HttpContext.Session.GetString("user") == null)
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
        }*/

        var model = _categoryServices.GetById(id);
        if (model == null)
        {
            TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Delete(int id, CategoryDTO category)
    {
        try
        {
            _categoryServices.Delete(id);
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
        var categories = _categoryServices.GetAll();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult DisplayDropdownList(string CategoryID)
    {
        ViewBag.CategoryID = CategoryID;
        ViewBag.Message = $"You selected {CategoryID}";

        ViewBag.Categories = _categoryServices.GetAll();

        return View();
    }

}
