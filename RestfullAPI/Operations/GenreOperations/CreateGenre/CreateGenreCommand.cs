﻿using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if(genre is not null)
            {
                throw new InvalidOperationException("Kitap türü mevcut");
            }
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
