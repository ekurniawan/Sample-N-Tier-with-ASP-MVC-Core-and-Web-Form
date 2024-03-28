namespace MyRESTServices.Data.Models
{
    public class usp_GetArticlesByCategoryId
    {
        public int ArticleID { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryID { get; set; }
    }
}
