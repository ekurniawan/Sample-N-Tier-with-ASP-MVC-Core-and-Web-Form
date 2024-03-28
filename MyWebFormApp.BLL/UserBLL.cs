using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;
using MyWebFormApp.DAL;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebFormApp.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL userDAL;
        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public void ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Delete(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = userDAL.GetAll();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Email = user.Email,
                    Telp = user.Telp
                });
            }
            return usersDTO;
        }

        public IEnumerable<UserDTO> GetAllWithRoles()
        {
            var users = userDAL.GetAllWithRoles();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                var userDto = new UserDTO
                {
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Email = user.Email,
                    Telp = user.Telp
                };
                var lstRolesDto = new List<RoleDTO>();
                var roles = user.Roles;
                foreach (var role in roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }

                userDto.Roles = lstRolesDto;
                usersDTO.Add(userDto);
            }
            return usersDTO;
        }

        public UserDTO GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserWithRoles(string username)
        {
            var user = userDAL.GetUserWithRoles(username);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var userDto = new UserDTO
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Telp = user.Telp
            };
            var lstRolesDto = new List<RoleDTO>();
            var roles = user.Roles;
            foreach (var role in roles)
            {
                lstRolesDto.Add(new RoleDTO
                {
                    RoleID = role.RoleID,
                    RoleName = role.RoleName
                });
            }

            userDto.Roles = lstRolesDto;

            return userDto;
        }

        public void Insert(UserCreateDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(entity.Password))
            {
                throw new ArgumentException("Password is required");
            }
            if (string.IsNullOrEmpty(entity.FirstName))
            {
                throw new ArgumentException("First Name is required");
            }
            if (string.IsNullOrEmpty(entity.LastName))
            {
                throw new ArgumentException("Last Name is required");
            }
            if (string.IsNullOrEmpty(entity.Address))
            {
                throw new ArgumentException("Address is required");
            }
            if (string.IsNullOrEmpty(entity.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (string.IsNullOrEmpty(entity.Telp))
            {
                throw new ArgumentException("Telp is required");
            }
            if (entity.Password != entity.Repassword)
            {
                throw new ArgumentException("Password and Re-Password must be same");
            }

            try
            {
                var newUser = new User
                {
                    Username = entity.Username,
                    Password = Helper.GetHash(entity.Password),
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Address = entity.Address,
                    Email = entity.Email,
                    Telp = entity.Telp
                };
                userDAL.Insert(newUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("Username already exists");
                }

                throw new ArgumentException(ex.Message);
            }
        }

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = userDAL.Login(username, Helper.GetHash(password));
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }

                var lstRolesDto = new List<RoleDTO>();
                var roles = result.Roles;
                foreach (var role in roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }

                UserDTO userDTO = new UserDTO
                {
                    Username = result.Username,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Address,
                    Email = result.Email,
                    Telp = result.Telp,
                    Roles = lstRolesDto
                };

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public UserDTO LoginMVC(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(loginDTO.Password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = userDAL.Login(loginDTO.Username, Helper.GetHash(loginDTO.Password));
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }

                var lstRolesDto = new List<RoleDTO>();
                var roles = result.Roles;
                foreach (var role in roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }

                UserDTO userDTO = new UserDTO
                {
                    Username = result.Username,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Address,
                    Email = result.Email,
                    Telp = result.Telp,
                    Roles = lstRolesDto
                };

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
