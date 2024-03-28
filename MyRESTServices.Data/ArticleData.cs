using Microsoft.EntityFrameworkCore;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.Data
{
    public class ArticleData : IArticleData
    {
        private readonly AppDbContext _context;
        public ArticleData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var delArticle = await _context.Articles.SingleOrDefaultAsync(a => a.ArticleId == id);
                if (delArticle == null)
                {
                    throw new ArgumentException("Article not found");
                }
                _context.Articles.Remove(delArticle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            var articles = await _context.Articles.OrderBy(a => a.Title).ToListAsync();
            return articles;
        }

        public async Task<IEnumerable<Article>> GetArticleByCategory(int categoryId)
        {
            var articles = await _context.Articles
                .Where(a => a.CategoryId == categoryId)
                .OrderBy(a => a.Title)
                .ToListAsync();
            return articles;
        }

        public async Task<IEnumerable<Article>> GetArticleWithCategory()
        {
            var articles = await _context.Articles
                .Include(a => a.Category)
                .OrderBy(a => a.Title)
                .ToListAsync();
            return articles;
        }

        public async Task<Article> GetById(int id)
        {
            var article = await _context.Articles.Include(a => a.Category).SingleOrDefaultAsync(a => a.ArticleId == id);
            if (article == null)
            {
                throw new ArgumentException("Article not found");
            }
            return article;
        }

        public async Task<int> GetCountArticles()
        {
            var count = await _context.Articles.CountAsync();
            return count;
        }

        public async Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            var articles = await _context.Articles
                .Where(a => a.CategoryId == categoryId)
                .OrderBy(a => a.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return articles;
        }

        public async Task<Article> Insert(Article entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Task> InsertArticleWithCategory(Article article)
        {
            try
            {
                _context.Categories.Add(article.Category);
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<int> InsertWithIdentity(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> Update(int id, Article entity)
        {
            try
            {
                var updateArticle = await _context.Articles.SingleOrDefaultAsync(a => a.ArticleId == id);
                if (updateArticle == null)
                {
                    throw new ArgumentException("Article not found");
                }
                updateArticle.Title = entity.Title;
                updateArticle.Details = entity.Details;
                updateArticle.PublishDate = entity.PublishDate;
                updateArticle.IsApproved = entity.IsApproved;
                updateArticle.Pic = entity.Pic;
                //updateArticle.Username = entity.Username;
                updateArticle.CategoryId = entity.CategoryId;

                await _context.SaveChangesAsync();
                return updateArticle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
