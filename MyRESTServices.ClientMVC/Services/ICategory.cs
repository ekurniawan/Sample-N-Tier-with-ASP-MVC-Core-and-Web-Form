using MyRESTServices.ClientMVC.Models;

namespace MyRESTServices.ClientMVC.Services
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAll(string token);
    }
}
