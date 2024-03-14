using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

namespace MyRESTServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            var results = _categoryBLL.GetAll();
            return results;
        }
    }
}
