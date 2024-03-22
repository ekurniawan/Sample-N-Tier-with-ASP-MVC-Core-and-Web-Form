using MyRESTServices.BLL.DTOs;

namespace SampleMVC.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO);
        Task Update(int id, CategoryUpdateDTO categoryUpdateDTO);
        Task Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name);
        Task<int> GetCountCategories(string name);
    }
}
