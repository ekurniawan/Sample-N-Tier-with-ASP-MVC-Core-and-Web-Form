using MyWebFormApp.BO;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IUserDAL : ICrud<User>
    {
        User GetByUsername(string username);
        User Login(string username, string password);
        void ChangePassword(string username, string newPassword);
    }
}
