using MyRESTServices.BLL.DTOs;

namespace SampleMVC.Services
{
    public interface IAccount
    {
        Task<string> Login(LoginDTO loginDTO);
    }
}
