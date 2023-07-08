using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Interfaces;
using NewsAndFuture.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Linq;

namespace NewsAndFuture.Providers
{
    public class NewsProvider : INewsProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NewsProvider(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiKey = configuration["NewsApi:ApiKey"];
        }

        public async Task<List<Article>> GetHeadlines()
        {
            var url = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NewsApiResponse>(content);
            return result?.Articles?.Where(article => !string.IsNullOrEmpty(article.UrlToImage)).ToList();
        }

        public async Task<List<Article>> Search(string search)
        {
            var encodedSearch = Uri.EscapeDataString(search);
            var url = $"https://newsapi.org/v2/everything?q={encodedSearch}&apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NewsApiResponse>(content);
            return result?.Articles?.Where(article => !string.IsNullOrEmpty(article.UrlToImage)).ToList();
        }
    }

}
