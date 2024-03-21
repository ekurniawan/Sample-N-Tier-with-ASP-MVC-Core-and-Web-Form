using AutoMapper;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryData _categoryData;
        private readonly IMapper _mapper;

        public CategoryBLL(ICategoryData categoryData, IMapper mapper)
        {
            _categoryData = categoryData;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _categoryData.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = await _categoryData.GetAll();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _categoryData.GetById(id);
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDTO>> GetByName(string name)
        {
            var categories = await _categoryData.GetByName(name);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public async Task<int> GetCountCategories(string name)
        {
            var count = await _categoryData.GetCountCategories(name);
            return count;
        }

        public async Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            var categories = await _categoryData.GetWithPaging(pageNumber, pageSize, name);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDTO> Insert(CategoryCreateDTO entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                var result = await _categoryData.Insert(category);
                var categoryDto = _mapper.Map<CategoryDTO>(result);
                return categoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryDTO> Update(int id, CategoryUpdateDTO entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                await _categoryData.Update(id, category);
                var categoryDto = _mapper.Map<CategoryDTO>(category);
                return categoryDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
