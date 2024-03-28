namespace MyRESTServices.BLL.DTOs
{
    public class usp_GetArticlesByCategoryIdDTO
    {
        public int ArticleID { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public int CategoryID { get; set; }
    }
}
