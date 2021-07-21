using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Interfaces;
using NewsAndFuture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAndFuture.Providers
{
    public class NewsapiProvider : INewsProvider
    {
        public Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
