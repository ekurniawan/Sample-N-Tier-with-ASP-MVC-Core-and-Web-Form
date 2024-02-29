using MyWebFormApp.BO;
using System.Collections.Generic;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IArticleDAL : ICrud<Article>
    {
        IEnumerable<Article> GetArticleWithCategory();
        IEnumerable<Article> GetArticleByCategory(int categoryId);
        int InsertWithIdentity(Article article);
    }
}
