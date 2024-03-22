using Microsoft.EntityFrameworkCore;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.Data
{
    public class RoleData : IRoleData
    {
        private readonly AppDbContext _context;
        public RoleData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Task> AddUserToRole(string username, int roleId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
            if (role == null)
            {
                throw new ArgumentException("Role not found");
            }

            try
            {
                role.Usernames.Add(user);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var role = await GetById(id);
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var roles = await _context.Roles.OrderBy(r => r.RoleName).ToListAsync();
            return roles;
        }

        public async Task<Role> GetById(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if (role == null)
            {
                throw new ArgumentException("Role not found");
            }
            return role;
        }

        public async Task<Role> Insert(Role entity)
        {
            try
            {
                _context.Roles.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Role> Update(int id, Role entity)
        {
            try
            {
                var role = await GetById(id);
                role.RoleName = entity.RoleName;
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
