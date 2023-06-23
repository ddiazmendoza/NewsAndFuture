using System.Threading.Tasks;
using NewsAndFuture.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace NewsAndFuture
{
    public class APIConnection
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://newsapi.org/v2/everything?")
        };
        public static async Task<List<Article>> GetTopHeadlinesAsync(string country) 
        {
            var url = "http://newsapi.org/v2/top-headlines?" +
            $"country={country}&" +
            "sortBy=popularity&" +
            "apiKey=fb86b8988414247fb9b0000140cc3838c";

            var myClient = new HttpClient() {BaseAddress = new Uri(url)};

            try
            {
                var request = await myClient.GetAsync(myClient.BaseAddress);

                var articles = new List<Article>();
                

                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();             
                    var articlesRoot = JsonSerializer.Deserialize<ArticlesRoot>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(articlesRoot.Status + " Artículos encontrados: " +  articlesRoot.Articles.Count);
                    articles = articlesRoot.Articles;
                }
                else
                {
                    Console.WriteLine("Request error");
                }
                return articles;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static async Task<List<Article>> GetArticlesSearchAsync(string _lang, string _search)
        {
            var q = _search;
            var lang = _lang;
            var from = DateTime.Now.ToShortDateString(); // Fecha actual
            var url = client.BaseAddress;
            var endpoint = url +
            $"q={q}&" +
            $"language={lang}&" +
            $"from={from}&" +
            "sortBy=popularity&" +
            "apiKey=fb86b898844247fb9b0000140cc3838c";

            try
            {
                ArticlesRoot answer = new();
                string request = await client.GetStringAsync(endpoint);

                if (request != null)
                {

                    answer = JsonSerializer.Deserialize<ArticlesRoot>(request, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(answer.Status + " Found articles: " + answer.Articles.Count);
                    return new List<Article>(answer.Articles);
                }

                else
                {
                    Console.WriteLine("Request error" + request);
                    Console.WriteLine(request.ToString());
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static async Task<ArticlesRoot> Search(string search, string language)
        {
            var q = search;
            var lang = language;
            var from = DateTime.Now.ToShortDateString(); // Fecha actual
                
            var url = "http://newsapi.org/v2/everything?" +
            $"q={q}&" +
            $"language={lang}&" +
            $"from={from}&" +
            "sortBy=popularity&" +
            "pageSize=100&" +
            "apiKey=fb86b898844247fb9b0000140cc3838c";

            var myClient = new HttpClient() {BaseAddress = new Uri(url)};

            try
            {
                var request = await myClient.GetAsync(myClient.BaseAddress);

                var myModel = new ArticlesRoot();
                    

                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();             
                    var model = JsonSerializer.Deserialize<ArticlesRoot>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(model.Status + " Artículos encontrados: " +  model.Articles.Count);
                    myModel = model;
                }
                else
                {
                    Console.WriteLine("Request error");
                }
                return myModel;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}