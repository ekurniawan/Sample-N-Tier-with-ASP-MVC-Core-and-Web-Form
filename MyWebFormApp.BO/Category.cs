using System.Collections.Generic;

namespace MyWebFormApp.BO
{
    public class Category
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}
