using AmazingApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmazingApi.DbContexts
{
    public class BookContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Server=localhost;Database=Books;Trusted_Connection=True;");
    }
}
