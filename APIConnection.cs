using System.Threading.Tasks;
using NewsAndFuture.Models;
using System;
using System.Net.Http;
using System.Text.Json;

namespace NewsAndFuture
{
    public class APIConnection
    {
        public static async Task<ArticlesRoot> GetTopHeadlines (string country) 
        {
            var url = "http://newsapi.org/v2/top-headlines?" +
            $"country={country}&" +
            "sortBy=popularity&" +
            "apiKey=fb86b8988414247fb9b0000140cc3838c";

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