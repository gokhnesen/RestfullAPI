using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;

namespace RestfullAPI.DbOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options):base(options)
        {
   
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
