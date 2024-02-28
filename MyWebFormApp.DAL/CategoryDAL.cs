using Dapper;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MyWebFormApp.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"DELETE FROM [Categories] WHERE [CategoryID] = @CategoryID";
                var param = new { CategoryID = id };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                //var strSql = @"select * from Categories order by CategoryName";
                var strSql = @"usp_GetCategories";

                var results = conn.Query<Category>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Categories where CategoryID = @CategoryID";
                var param = new { CategoryID = id };
                var result = conn.QuerySingleOrDefault<Category>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Category> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "usp_CreateCategory";
                var param = new { CategoryName = entity.CategoryName };
                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Insert data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Update(Category entity)
        {

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"UPDATE [Categories] SET [CategoryName] = @CategoryName WHERE [CategoryID] = @CategoryID";
                    var param = new { CategoryName = entity.CategoryName, CategoryID = entity.CategoryID };
                    int result = conn.Execute(strSql, param);

                    //jika result = -1, berarti update data gagal
                    if (result != 1)
                    {
                        throw new Exception("Update data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}
