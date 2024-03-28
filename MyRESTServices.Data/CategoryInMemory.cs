using Microsoft.EntityFrameworkCore;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.Data
{
    public class CategoryInMemory : ICategoryData
    {
        private readonly AppDbContext _appDbContext;
        public CategoryInMemory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            //var categories = await _appDbContext.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            var categories = await (from c in _appDbContext.Categories
                                    orderby c.CategoryName ascending
                                    select c).ToListAsync();
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

        public async Task<Category> Insert(Category entity)
        {
            try
            {
                _appDbContext.Categories.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
