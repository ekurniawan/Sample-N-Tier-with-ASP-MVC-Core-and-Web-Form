using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data.Interfaces;

namespace MyRESTServices.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryData _categoryData;
        public CategoryBLL(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Insert(CategoryCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Update(CategoryUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
