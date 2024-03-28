using Dapper;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWebFormApp.DAL
{
    public class UserDAL : IUserDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void ChangePassword(string username, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Users order by Username";
                var results = conn.Query<User>(strSql);
                return results;
            }
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(User entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"insert into Users(Username,Password,FirstName,LastName,Address,Email,Telp) 
                values(@Username,@Password,@FirstName,@LastName,@Address,@Email,@Telp)";
                    var param = new
                    {
                        Username = entity.Username,
                        Password = entity.Password,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Address = entity.Address,
                        Email = entity.Email,
                        Telp = entity.Telp
                    };

                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new System.Exception("Data tidak berhasil ditambahkan");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public User Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Users where Username = @Username and Password = @Password";
                var param = new { Username = username, Password = password };
                var result = conn.QueryFirstOrDefault<User>(strSql, param);
                if (result == null)
                {
                    throw new ArgumentException("Username atau Password salah");
                }

                var strSqlRole = @"select r.* from UsersRoles ur
                               inner join Roles r on ur.RoleID = r.RoleID
                               where ur.Username = @Username";
                var roles = conn.Query<Role>(strSqlRole, param);
                result.Roles = roles;

                return result;
            }
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Users where Username = @Username";
                var param = new { Username = username };
                var result = conn.QueryFirstOrDefault<User>(strSql, param);
                return result;
            }
        }

        public IEnumerable<User> GetAllWithRoles()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Users";
                var users = conn.Query<User>(strSql);
                foreach (var user in users)
                {
                    strSql = @"select r.* from UsersRoles ur
                               inner join Roles r on ur.RoleId = r.RoleId
                               where ur.Username = @Username";
                    var param = new { Username = user.Username };
                    var roles = conn.Query<Role>(strSql, param);
                    user.Roles = roles;
                }
                return users;
            }
        }

        public User GetUserWithRoles(string username)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Users where Username=@Username";
                var param = new { Username = username };
                var user = conn.QuerySingleOrDefault<User>(strSql, param);

                if (user != null)
                {
                    strSql = @"select r.* from UsersRoles ur
                               inner join Roles r on ur.RoleId = r.RoleId
                               where ur.Username = @Username";
                    var paramRole = new { Username = user.Username };
                    var roles = conn.Query<Role>(strSql, paramRole);
                    user.Roles = roles;
                }

                return user;
            }
        }
    }
}
