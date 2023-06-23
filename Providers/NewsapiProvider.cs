using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Interfaces;
using NewsAndFuture.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsAndFuture.Providers
{
    public class NewsapiProvider : INewsProvider
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(@"http://newsapi.org/v2/everything?")
        };
        public async Task<List<Article>> GetArticlesSearchAsync(string _lang, string _search)
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
        public async Task<List<Article>> GetTopHeadlinesAsync(string country)
        {      
            var url = @"http://newsapi.org/v2/top-headlines?";
            var endpoint = url + 
                $"country={country}&" +
                "sortBy=popularity&" +
                "apiKey=fb86b898844247fb9b0000140cc3838c";

            try
            {
                var request = await client.GetAsync(endpoint);

                var articles = new List<Article>();


                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    var articlesRoot = JsonSerializer.Deserialize<ArticlesRoot>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    System.Console.WriteLine(articlesRoot.Status + " Artículos encontrados: " + articlesRoot.Articles.Count);
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
    }
}
