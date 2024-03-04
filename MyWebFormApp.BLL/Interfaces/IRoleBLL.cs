using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;

namespace MyWebFormApp.BLL.Interfaces
{
    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAllRoles();
        void AddRole(string roleName);
        void AddUserToRole(string username, int roleId);
    }
}
