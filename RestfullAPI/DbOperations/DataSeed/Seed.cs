using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;

namespace RestfullAPI.DbOperations.DataSeed
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                new Book
                {
                    Title = "Lean Startup",
                    GenreId = 1,
                    AuthorId = 3,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    Title = "Herland",
                    GenreId = 2,
                    AuthorId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Book
                {
                    Title = "Dune",
                    GenreId = 2,
                    AuthorId = 1,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21)
                }

                );
                context.Users.Add(
                new User()
                {
                    Id = 1,
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
                context.Authors.AddRange(
                new Author()
                {
                    Name = "Frank".ToLower(),
                    Surname = "Herbert".ToLower(),
                    DateOfBirth = new DateTime(1920,10,8),
                   
                },
                new Author()
                {
                    Name = "Charlotte Perkins".ToLower(),
                    Surname = "Gilman".ToLower(),
                    DateOfBirth= new DateTime(1860,7,3)
                },
                new Author()
                {
                    Name ="Eric".ToLower(),
                    Surname = "Ries".ToLower(),
                    DateOfBirth = new DateTime(1978,9,22)
                }
                );
                context.SaveChanges();


            }
        }
    }
}
