﻿using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;

namespace RestfullAPI.DbOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Books> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
}
