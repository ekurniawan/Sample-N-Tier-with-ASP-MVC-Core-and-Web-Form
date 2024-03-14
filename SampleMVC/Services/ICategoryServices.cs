using MyWebFormApp.BO;

namespace SampleMVC.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
