using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;

namespace MyWebFormApp.BLL.Interfaces
{
    public interface IArticleBLL
    {
        IEnumerable<ArticleDTO> GetArticleWithCategory();
    }
}
