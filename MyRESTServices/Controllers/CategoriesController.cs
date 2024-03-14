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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _categoryBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null)
            {
                return BadRequest();
            }

            try
            {
                _categoryBLL.Insert(categoryCreateDTO);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            if (_categoryBLL.GetById(id) == null)
            {
                return NotFound();
            }

            try
            {
                _categoryBLL.Update(categoryUpdateDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_categoryBLL.GetById(id) == null)
            {
                return NotFound();
            }

            try
            {
                _categoryBLL.Delete(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
