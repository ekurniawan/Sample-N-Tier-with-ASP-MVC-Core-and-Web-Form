using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data.Interfaces;

namespace MyRESTServices.BLL
{
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleData _roleData;
        public RoleBLL(IRoleData roleData)
        {
            _roleData = roleData;
        }

        public Task<Task> AddRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> AddUserToRole(string username, int roleId)
        {
            try
            {
                await _roleData.AddUserToRole(username, roleId);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
