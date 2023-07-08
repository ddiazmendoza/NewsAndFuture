using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

namespace NewsAndFuture.Interfaces
{
    public interface INewsProvider
    {
        public Task<List<Article>> GetArticlesSearchAsync(Languages lang, string search);
        public Task<List<Article>> GetTopHeadlinesAsync(Countries country);

    }
}
