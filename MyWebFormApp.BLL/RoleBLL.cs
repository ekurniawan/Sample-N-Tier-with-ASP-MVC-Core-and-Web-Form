using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebFormApp.BLL
{
    public class RoleBLL : IRoleBLL
    {
        IRoleDAL roleDAL;
        public RoleBLL()
        {
            roleDAL = new DAL.RoleDAL();
        }

        public void AddRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new System.ArgumentException("Role Name is required");
            }

            try
            {
                roleDAL.Insert(new Role { RoleName = roleName });
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void AddUserToRole(string username, int roleId)
        {
            try
            {
                roleDAL.AddUserToRole(username, roleId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var results = roleDAL.GetAll();
            var resultsDTO = new List<RoleDTO>();
            foreach (var item in results)
            {
                resultsDTO.Add(new RoleDTO
                {
                    RoleID = item.RoleID,
                    RoleName = item.RoleName
                });
            }
            return resultsDTO;
        }
    }
}
