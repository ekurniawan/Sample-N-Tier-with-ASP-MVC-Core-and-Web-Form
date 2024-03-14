using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
