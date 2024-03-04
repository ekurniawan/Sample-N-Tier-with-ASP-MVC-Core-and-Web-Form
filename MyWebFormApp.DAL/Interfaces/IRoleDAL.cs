using MyWebFormApp.BO;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IRoleDAL : ICrud<Role>
    {
        void AddUserToRole(string username, int roleId);
    }
}
