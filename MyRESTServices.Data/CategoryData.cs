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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var category = await GetById(id);
                if (category == null)
                {
                    throw new ArgumentException("Category not found");
                }
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            //var categories = await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();

            //use sqlraw for ef
            var categories = await _context.Categories.FromSqlRaw("usp_GetCategories").ToListAsync();
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            var categories = await _context.Categories
                .Where(c => c.CategoryName.Contains(name))
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
            return categories;
        }

        public async Task<int> GetCountCategories(string name)
        {
            var count = await _context.Categories
                .Where(c => c.CategoryName.Contains(name))
                .CountAsync();
            return count;
        }

        public async Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            var categories = await _context.Categories
                .Where(c => c.CategoryName.Contains(name))
                .OrderBy(c => c.CategoryName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return categories;
        }

        public async Task<Category> Insert(Category entity)
        {
            try
            {
                _context.Categories.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id, Category entity)
        {
            try
            {
                var category = await GetById(id);
                if (category == null)
                {
                    throw new ArgumentException("Category not found");
                }
                category.CategoryName = entity.CategoryName;
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
