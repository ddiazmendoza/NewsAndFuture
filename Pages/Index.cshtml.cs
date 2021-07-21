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

namespace NewsAndFuture.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INewsProvider newsProvider;
        public List<Article> SEARCH_A { get; set; }
        public IndexModel(INewsProvider newsProvider)
        {
            this.newsProvider = newsProvider;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await newsProvider.GetAllAsync();
            
           
        }
        
    }
}
