using MyWebFormApp.BO;
using System.Collections.Generic;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IUserDAL : ICrud<User>
    {
        IEnumerable<User> GetAllWithRoles();
        User GetByUsername(string username);
        User Login(string username, string password);
        void ChangePassword(string username, string newPassword);
    }
}
