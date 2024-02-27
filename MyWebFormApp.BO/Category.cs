using System.Collections.Generic;

namespace MyWebFormApp.BO
{
    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
