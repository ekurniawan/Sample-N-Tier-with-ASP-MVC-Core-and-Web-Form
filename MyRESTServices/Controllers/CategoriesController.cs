using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;

namespace MyRESTServices.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        private readonly IValidator<CategoryCreateDTO> _validatorCategoryCreateDto;
        private readonly IValidator<CategoryUpdateDTO> _validatorCategoryUpdateDto;

        public CategoriesController(ICategoryBLL categoryBLL,
            IValidator<CategoryCreateDTO> validatorCategoryCreateDto,
            IValidator<CategoryUpdateDTO> validatorCategoryUpdateDto)
        {
            _categoryBLL = categoryBLL;
            _validatorCategoryCreateDto = validatorCategoryCreateDto;
            _validatorCategoryUpdateDto = validatorCategoryUpdateDto;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var results = await _categoryBLL.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, CategoryCreateDTO categoryCreateDTO)
        {
            var validateResult = await _validatorCategoryCreateDto.ValidateAsync(categoryCreateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                var newCategory = await _categoryBLL.Insert(categoryCreateDTO);
                return CreatedAtAction("Get", new { id = id }, newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var validateResult = await _validatorCategoryUpdateDto.ValidateAsync(categoryUpdateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                await _categoryBLL.Update(id, categoryUpdateDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryBLL.Delete(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
