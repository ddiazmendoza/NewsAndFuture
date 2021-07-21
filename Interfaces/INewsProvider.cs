using Microsoft.AspNetCore.Mvc;
using NewsAndFuture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAndFuture.Interfaces
{
    public interface INewsProvider
    {
        public Task<IActionResult> GetAllAsync();
        public Task<Article> GetAsync();

    }
}
