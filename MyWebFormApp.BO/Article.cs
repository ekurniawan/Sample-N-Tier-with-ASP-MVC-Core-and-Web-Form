using System;

namespace MyWebFormApp.BO
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsApproved { get; set; }
        public string Pic { get; set; }
        public string Username { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}
