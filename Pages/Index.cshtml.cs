using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NewsAndFuture.Models;

namespace NewsAndFuture.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public static async Task<List<Article>> GetArticles(string search, string lang) 
        {
            try
            {
                var articles = await APIConnection.EstablishConnectionAsync(search, lang);
                var _art = articles.Articles;
                return _art;    
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; // TODO
            }
            
        }
       
    }
}
