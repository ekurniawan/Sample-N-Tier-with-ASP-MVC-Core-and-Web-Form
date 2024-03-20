using MyRESTServices.BLL.DTOs;

namespace MyRESTServices.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task<Task> ChangePassword(string username, string newPassword);
        Task<Task> Delete(string username);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByUsername(string username);
        Task<Task> Insert(UserCreateDTO entity);
        Task<UserDTO> Login(string username, string password);
        Task<UserDTO> LoginMVC(LoginDTO loginDTO);

        Task<UserDTO> GetUserWithRoles(string username);
        Task<IEnumerable<UserDTO>> GetAllWithRoles();
    }
}
