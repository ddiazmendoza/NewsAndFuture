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
        Task<List<Article>> GetHeadlines();
        Task<List<Article>> Search(string search);
    }

}
