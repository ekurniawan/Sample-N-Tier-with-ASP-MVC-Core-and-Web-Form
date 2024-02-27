using MyWebFormApp.BO;
using System.Collections.Generic;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface ICategoryDAL : ICrud<Category>
    {
        IEnumerable<Category> GetByName(string name);
    }
}
