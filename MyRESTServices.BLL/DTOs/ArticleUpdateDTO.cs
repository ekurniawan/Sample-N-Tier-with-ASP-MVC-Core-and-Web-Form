namespace MyRESTServices.BLL.DTOs
{
    public class ArticleUpdateDTO
    {
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool IsApproved { get; set; }
        public string Pic { get; set; }
    }
}
