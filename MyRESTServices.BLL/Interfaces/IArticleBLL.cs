
using MyRESTServices.BLL.DTOs;

namespace MyRESTServices.BLL.Interfaces
{
    public interface IArticleBLL
    {
        Task<ArticleDTO> Insert(ArticleCreateDTO article);
        Task<IEnumerable<ArticleDTO>> GetArticleWithCategory();
        Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId);
        Task<int> InsertWithIdentity(ArticleCreateDTO article);
        Task<ArticleDTO> Update(int id, ArticleUpdateDTO article);
        Task<bool> Delete(int id);
        Task<ArticleDTO> GetArticleById(int id);
        Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize);
        Task<int> GetCountArticles();
    }
}
