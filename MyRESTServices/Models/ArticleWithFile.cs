namespace MyRESTServices.Models
{
    public class ArticleWithFile
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public bool? IsApproved { get; set; } = false;
        public IFormFile? file { get; set; }
    }
}
