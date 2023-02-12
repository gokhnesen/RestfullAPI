using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;

namespace RestfullAPI.DbOperations.DataSeed
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context= new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                new Books
                {
                    Title = "Lean Startup",
                    GenreId = 1, 
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Books
                {
                    Title = "Herland",
                    GenreId = 2, 
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Books
                {
                    Title = "Dune",
                    GenreId = 2,  
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21)
                }

                );
                context.Users.Add(
                new User()
                {
                    Id=1,
                    Username = "admin",
                    Password = "12345",
                }
                );
                context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth"
                    },
                    new Genre()
                    {
                        Name = "Science Fiction"
                    },
                    new Genre()
                    {
                        Name = "Romance"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
