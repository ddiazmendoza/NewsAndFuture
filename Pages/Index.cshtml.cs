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
        private readonly INewsProvider _newsProvider;

        public IndexModel(INewsProvider newsProvider)
        {
            _newsProvider = newsProvider;
        }

        public List<Article> Headlines { get; set; }

        public async Task<IActionResult> OnGetAsync(string search)
        {
            try
            {
                if (!string.IsNullOrEmpty(search))
                {
                    var encodedSearch = Uri.EscapeDataString(search);
                    Headlines = await _newsProvider.Search(encodedSearch);
                }
                else
                {
                    Headlines = await _newsProvider.GetHeadlines();
                }
            }
            catch (HttpRequestException)
            {
                // Handle 400 Bad Request error
                Headlines = new List<Article>();
                ModelState.AddModelError(string.Empty, "Error: Failed to retrieve headlines. Please try again later.");
            }

            return Page();
        }
    }
}
