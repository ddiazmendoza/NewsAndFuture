using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAndFuture.Interfaces
{
    public interface INewsProvider
    {
        public Task<List<Article>> GetArticlesSearchAsync(string _lang, string _search);
        public Task<List<Article>> GetTopHeadlinesAsync(string country);

    }
}
