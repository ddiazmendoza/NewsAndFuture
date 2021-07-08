using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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

        public async void OnGet()
        {
            
           
        }
        public static async Task<List<Article>> GetArticles(string search, string lang) 
        {
            try
            {
                var articles = await APIConnection.Search(search, lang);
                var _art = articles.Articles;
                return _art;    
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; // TODO
            }

        }
        
        public static async Task<List<Article>> GetTopHeadlines() 
        {
            try
            {
                var ArticlesRoot = await APIConnection.GetTopHeadlines("us");
                var Articles = ArticlesRoot.Articles;
                System.Console.WriteLine($"Artículos top headlines mex encontrados: {Articles.Count}");
                return Articles;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            
        }
         public static async Task<Currency> GetCurrencies(string SEARCH, string USDorBTC) 
        {

            var sochainClient = new HttpClient() {BaseAddress = new Uri($@"https://sochain.com/api/v2/get_price/{SEARCH}/{USDorBTC}")};
            try
            {
                var request = await sochainClient.GetAsync(sochainClient.BaseAddress);
                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    var deserializedContent = System.Text.Json.JsonSerializer.Deserialize<Currency>(content, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
                    return deserializedContent;
                } 
                else 
                {
                    System.Console.WriteLine("error wey");
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
