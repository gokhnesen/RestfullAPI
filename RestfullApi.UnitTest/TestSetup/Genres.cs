using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
                });
        }
    }
}
