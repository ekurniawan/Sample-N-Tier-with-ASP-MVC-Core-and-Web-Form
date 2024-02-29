using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;

namespace MyWebFormApp.BLL.Interfaces
{
    public interface IArticleBLL
    {
        void Insert(ArticleCreateDTO article);
        IEnumerable<ArticleDTO> GetArticleWithCategory();
        IEnumerable<ArticleDTO> GetArticleByCategory(int categoryId);
        int InsertWithIdentity(ArticleCreateDTO article);
    }
}
