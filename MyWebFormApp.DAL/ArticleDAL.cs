using Dapper;
using MyWebFormApp.BO;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using static Dapper.SqlMapper;

namespace MyWebFormApp.DAL
{
    public class ArticleDAL : IArticleDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"delete from Articles where ArticleID = @ArticleID";
                var param = new { ArticleID = id };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil dihapus");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public IEnumerable<Article> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Articles order by Title";
                var results = conn.Query<Article>(strSql);
                return results;
            }
        }

        public IEnumerable<Article> GetArticleWithCategory()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {

                var strSql = @"select a.ArticleID, a.CategoryID, a.Title, a.Details, a.PublishDate, a.IsApproved, a.Pic, c.CategoryID, c.CategoryName from Articles a inner join Categories c on a.CategoryID = c.CategoryID";
                /*var results = conn.Query<Article, Category, Article>(strSql, (article, category) =>
                {
                    article.Category = category;
                    return article;
                }, splitOn: "CategoryID");
                return results;*/

                //pakai ADO.NET
                List<Article> articles = new List<Article>();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var article = new Article()
                        {
                            ArticleID = Convert.ToInt32(dr["ArticleID"]),
                            CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            Title = dr["Title"].ToString(),
                            Details = dr["Details"].ToString(),
                            PublishDate = Convert.ToDateTime(dr["PublishDate"]),
                            IsApproved = Convert.ToBoolean(dr["IsApproved"]),
                            Pic = dr["Pic"].ToString(),
                            Category = new Category()
                            {
                                CategoryID = Convert.ToInt32(dr["CategoryID"]),
                                CategoryName = dr["CategoryName"].ToString()
                            }
                        };
                        articles.Add(article);
                    }
                }
                return articles;
            }
        }

        public Article GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Articles where ArticleID = @ArticleID";
                var param = new { ArticleID = id };
                var result = conn.QueryFirstOrDefault<Article>(strSql, param);
                return result;
            }
        }

        public void Insert(Article entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"insert into Articles(CategoryID, Title, Details, IsApproved, Pic) 
                               values(@CategoryID, @Title, @Details, @IsApproved, @Pic)";
                var param = new
                {
                    CategoryID = entity.CategoryID,
                    Title = entity.Title,
                    Details = entity.Details,
                    IsApproved = entity.IsApproved,
                    Pic = entity.Pic
                };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil ditambahkan");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public void Update(Article entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"update Articles set CategoryID=@CategoryID, Title=@Title, Details=@Details, IsApproved=@IsApproved, Pic=@Pic 
                               where ArticleID=@ArticleID";
                var param = new
                {
                    CategoryID = entity.CategoryID,
                    Title = entity.Title,
                    Details = entity.Details,
                    IsApproved = entity.IsApproved,
                    Pic = entity.Pic,
                    ArticleID = entity.ArticleID
                };

                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil diupdate");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public IEnumerable<Article> GetArticleByCategory(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {

                var strSql = @"select a.ArticleID, a.CategoryID, a.Title, a.Details, a.PublishDate, a.IsApproved, a.Pic, c.CategoryID, c.CategoryName from Articles a inner join Categories c on a.CategoryID = c.CategoryID 
                               where a.CategoryID=@CategoryID";
                var param = new { CategoryID = categoryId };
                var results = conn.Query<Article, Category, Article>(strSql, (article, category) =>
                {
                    article.Category = category;
                    return article;
                }, param, splitOn: "CategoryID");
                return results;
            }
        }

        public int InsertWithIdentity(Article article)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"insert into Articles(CategoryID, Title, Details, PublishDate, IsApproved, Pic) 
                               values(@CategoryID, @Title, @Details, @PublishDate, @IsApproved, @Pic);
                               select @@identity";
                var param = new
                {
                    CategoryID = article.CategoryID,
                    Title = article.Title,
                    Details = article.Details,
                    PublishDate = article.PublishDate,
                    IsApproved = article.IsApproved,
                    Pic = article.Pic
                };
                try
                {
                    int result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                    return result;
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

        public void InsertArticleWithCategory(Article article)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = @"insert into Categories(CategoryName) values(@CategoryName);
                                   select @@identity";
                    var param = new { CategoryName = article.Category.CategoryName };
                    try
                    {
                        int categoryId = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                        article.CategoryID = categoryId;

                        var strSql2 = @"insert into Articles(CategoryID, Title, Details, PublishDate, IsApproved, Pic) 
                                       values(@CategoryID, @Title, @Details, @PublishDate, @IsApproved, @Pic)";
                        var param2 = new { CategoryID = article.CategoryID, Title = article.Title, Details = article.Details, PublishDate = article.PublishDate, IsApproved = article.IsApproved, Pic = article.Pic };
                        int result = conn.Execute(strSql2, param2);
                        if (result != 1)
                        {
                            throw new Exception("Data tidak berhasil ditambahkan");
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
                scope.Complete();
            }
        }

        //asumsi jika categoryId=0 maka select semua category
        public IEnumerable<Article> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                if (categoryId == 0)
                {
                    var strSql = @"select a.*,c.* from Articles a 
                               inner join Categories c on a.CategoryID = c.CategoryID 
                               order by CategoryName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                    var param = new { Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                    var results = conn.Query<Article, Category, Article>(strSql, (article, category) =>
                    {
                        article.Category = category;
                        return article;
                    }, param, splitOn: "CategoryID");
                    return results;
                }
                else
                {
                    var strSql = @"select a.*,c.* from Articles a 
                               inner join Categories c on a.CategoryID = c.CategoryID 
                               where a.CategoryID=@CategoryID 
                               order by CategoryName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                    var param = new { CategoryID = categoryId, Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                    var results = conn.Query<Article, Category, Article>(strSql, (article, category) =>
                    {
                        article.Category = category;
                        return article;
                    }, param, splitOn: "CategoryID");
                    return results;
                }
            }
        }

        public int GetCountArticles()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select count(*) from Articles";
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql));
                return result;
            }
        }


    }
}
