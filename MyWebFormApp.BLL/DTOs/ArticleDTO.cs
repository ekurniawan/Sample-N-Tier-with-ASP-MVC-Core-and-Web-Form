using System;

namespace MyWebFormApp.BLL.DTOs
{
    public class ArticleDTO
    {
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsApproved { get; set; }
        public string Pic { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
