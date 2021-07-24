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
        public async Task<ICollection> GetAllAsync(string country)
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
                return myModel.Articles;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<ICollection> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
