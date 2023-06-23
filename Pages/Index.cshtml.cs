using System;
using System.Collections.Generic;
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
        private readonly INewsProvider newsProvider;
        public List<Article> TopHeadlines { get; set; }
        public List<Article> CarouselItems { get; set; }

        public IndexModel(INewsProvider newsProvider)
        {
            this.newsProvider = newsProvider;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                CarouselItems = new List<Article>(await newsProvider.GetTopHeadlinesAsync("mx"));
                //CarouselItems = await newsProvider.GetArticlesSearchAsync("es", "amlo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            return Page();
            
           
        }
        
    }
}
