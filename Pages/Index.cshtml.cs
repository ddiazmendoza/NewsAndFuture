using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NewsAndFuture.Interfaces;
using NewsAndFuture.Models;
using NewsAndFuture.Providers;

namespace NewsAndFuture.Pages
{
    public class IndexModel : PageModel
    {
        private INewsProvider newsProvider;
        public List<Article> TopHeadlines { get; set; }
        public List<Article> NewsHeadliners { get; set; }

        public IndexModel(INewsProvider newsProvider)
        {
            this.newsProvider = newsProvider;
            NewsHeadliners = new List<Article>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                NewsHeadliners = await newsProvider.GetTopHeadlinesAsync("mx");
                //CarouselItems = await newsProvider.GetArticlesSearchAsync("es", "amlo");
                return Page();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Page();
            }

        }
        
    }
}
