using MyRESTServices.ClientMVC.Models;

namespace MyRESTServices.ClientMVC.Services
{
    public interface IAccount
    {
        Task<UserWithTokenViewModel> Login(LoginDTO loginDTO);
        Task<IEnumerable<string>> GetRolesByUser(string username);
    }
}
