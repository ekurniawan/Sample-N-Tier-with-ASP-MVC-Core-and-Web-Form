using Microsoft.EntityFrameworkCore;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.Data
{
    public class CategoryData : ICategoryData
    {
        private readonly AppDbContext _context;
        public CategoryData(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            return categories;
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(int id, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
