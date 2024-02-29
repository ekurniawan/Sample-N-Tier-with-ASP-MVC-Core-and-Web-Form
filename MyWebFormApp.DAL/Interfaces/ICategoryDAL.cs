using MyWebFormApp.BO;
using System.Collections.Generic;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface ICategoryDAL : ICrud<Category>
    {
        IEnumerable<Category> GetByName(string name);
        IEnumerable<Category> GetWithPaging(int pageNumber, int pageSize, string name);
        int GetCountCategories(string name);
        int InsertWithIdentity(Category category);
    }
}
