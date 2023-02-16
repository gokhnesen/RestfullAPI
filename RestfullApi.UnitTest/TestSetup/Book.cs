using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.TestSetup
{
    public static class Book
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
      new Books
      {
          Title = "Lean Startup",
          GenreId = 1,
          AuthorId = 3,
          PageCount = 200,
          PublishDate = new DateTime(2001, 06, 12)
      },
      new Books
      {
          Title = "Herland",
          GenreId = 2,
          AuthorId = 2,
          PageCount = 250,
          PublishDate = new DateTime(2010, 05, 23)
      },
      new Books
      {
          Title = "Dune",
          GenreId = 2,
          AuthorId = 1,
          PageCount = 540,
          PublishDate = new DateTime(2001, 12, 21)
      }

      );
        }
    }
}
