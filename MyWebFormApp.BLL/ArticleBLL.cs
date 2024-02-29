using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;
using MyWebFormApp.DAL;
using MyWebFormApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyWebFormApp.BLL
{
    public class ArticleBLL : IArticleBLL
    {
        private readonly IArticleDAL _articleDAL;
        public ArticleBLL()
        {
            _articleDAL = new ArticleDAL();
        }

        public IEnumerable<ArticleDTO> GetArticleByCategory(int categoryId)
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();
            var articlesFromDAL = _articleDAL.GetArticleByCategory(categoryId);
            foreach (var article in articlesFromDAL)
            {
                articles.Add(new ArticleDTO
                {
                    ArticleID = article.ArticleID,
                    CategoryID = article.CategoryID,
                    Title = article.Title,
                    Details = article.Details,
                    PublishDate = article.PublishDate,
                    IsApproved = article.IsApproved,
                    Pic = article.Pic,
                    Category = new CategoryDTO
                    {
                        CategoryID = article.Category.CategoryID,
                        CategoryName = article.Category.CategoryName
                    }
                });
            }
            return articles;
        }

        public IEnumerable<ArticleDTO> GetArticleWithCategory()
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();
            var articlesFromDAL = _articleDAL.GetArticleWithCategory();
            foreach (var article in articlesFromDAL)
            {
                articles.Add(new ArticleDTO
                {
                    ArticleID = article.ArticleID,
                    CategoryID = article.CategoryID,
                    Title = article.Title,
                    Details = article.Details,
                    PublishDate = article.PublishDate,
                    IsApproved = article.IsApproved,
                    Pic = article.Pic,
                    Category = new CategoryDTO
                    {
                        CategoryID = article.Category.CategoryID,
                        CategoryName = article.Category.CategoryName
                    }
                });
            }
            return articles;
        }

        public void Insert(ArticleCreateDTO articleDto)
        {
            if (string.IsNullOrEmpty(articleDto.Title))
            {
                throw new ArgumentException("Title is required");
            }
            if (string.IsNullOrEmpty(articleDto.Details))
            {
                throw new ArgumentException("Details is required");
            }

            try
            {
                var article = new Article
                {
                    CategoryID = articleDto.CategoryID,
                    Title = articleDto.Title,
                    Details = articleDto.Details,
                    IsApproved = articleDto.IsApproved,
                    Pic = articleDto.Pic
                };
                _articleDAL.Insert(article);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public int InsertWithIdentity(ArticleCreateDTO articleDto)
        {
            if (string.IsNullOrEmpty(articleDto.Title))
            {
                throw new ArgumentException("Title is required");
            }
            if (string.IsNullOrEmpty(articleDto.Details))
            {
                throw new ArgumentException("Details is required");
            }

            try
            {
                var article = new Article
                {
                    CategoryID = articleDto.CategoryID,
                    Title = articleDto.Title,
                    Details = articleDto.Details,
                    IsApproved = articleDto.IsApproved,
                    Pic = articleDto.Pic
                };
                int result = _articleDAL.InsertWithIdentity(article);
                return result;
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
