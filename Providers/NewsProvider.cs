using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Interfaces;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsAndFuture.Providers
{
    public class NewsProvider : INewsProvider
    {
        private readonly string apiKey = "fb86b898844247fb9b0000140cc3838c";
        private readonly NewsApiClient newsApiClient;

        public NewsProvider(string apiKey)
        {
            this.apiKey = apiKey;
            newsApiClient = new NewsApiClient(apiKey);
        }

        public async Task<List<Article>> GetArticlesSearchAsync(Languages lang, string search)
        {
            var request = new EverythingRequest
            {
                Language = Languages.ES,
                Q = search
            };

            var response = await newsApiClient.GetEverythingAsync(request);

            if (response.Status == Statuses.Ok)
            {
                return response.Articles;
            }
            else
            {
                // Handle error case
                return null;
            }
        }

        public async Task<List<Article>> GetTopHeadlinesAsync(Countries country)
        {
            var request = new TopHeadlinesRequest
            {
                Country = country
            };

            var response = await newsApiClient.GetTopHeadlinesAsync(request);

            if (response.Status == Statuses.Ok)
            {
                return response.Articles;
            }
            else
            {
                // Handle error case
                return null;
            }
        }
    }
}
