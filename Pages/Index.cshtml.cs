using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using Newtonsoft.Json;

namespace NewsAndFuture.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public List<Article> Headlines { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _clientFactory.CreateClient();

            var apiKey = "fb86b898844247fb9b0000140cc3838c"; // Replace with your NewsAPI API key
            var url = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={apiKey}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NewsApiResponse>(content);

                Headlines = result?.Articles;
            }
            else
            {
                // Handle error case
                Headlines = new List<Article>();
            }

            return Page();
        }
    }
}
