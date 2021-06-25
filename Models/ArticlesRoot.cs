using System.Collections.Generic;

namespace NewsAndFuture.Models
{
    public class ArticlesRoot
    {
        public string Status { get; set; }
        public int TotalResults {get; set;}
        public List<Article> Articles {get; set;}
    }
}