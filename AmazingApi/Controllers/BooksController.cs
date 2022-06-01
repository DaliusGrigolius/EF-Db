using AmazingApi.DbContexts;
using AmazingApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AmazingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        public void Insert([FromBody] string bookName)
        {
            using var dbContext = new BookContext();

            var book = new Book(bookName);

            for (int i = 0; i < 565; i++)
            {
                var page = new Page(i + 1, $"Content-{i}");
                book.Pages.Add(page);
            }

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        [HttpGet("{bookName}")]
        public List<string> GetBook([FromRoute] string bookName)
        {
            using var dbContext = new BookContext();

            var book = dbContext.Books
                .Where(i => i.Name == bookName)
                .Include(i => i.Pages)
                .First();

            List<string> strings = new List<string>();
            strings.Add($"BookId: {book.Id}, Name: {book.Name}, Pages: ");

            foreach (var page in book.Pages.OrderBy(i => i.Number))
            {
                strings.Add($"Number: {page.Number}. Content: {page.Content}");
            }

            return strings;
        }
    }
}
