using AmazingApi.DbContexts;
using AmazingApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagesController : ControllerBase
    {
        public PagesController()
        {

        }

        [HttpGet("{pages}")]
        public void GetPages()
        {
            
        }

        [HttpPost]
        public void Insert()
        {
            using var dbContext = new BookContext();

            Page page = new Page(5, "Ivadas");

            dbContext.Add(page);
            dbContext.SaveChanges();
        }

        [HttpDelete]
        public void Remove()
        {
            using var dbContext = new BookContext();

            Page page = new Page(new Guid("A7D690D3-60FD-425F-AF0D-B8743B6FE745"));

            dbContext.Remove(page);
            dbContext.SaveChanges();
        }
    }
}
