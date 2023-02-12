using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.Operations.GenreOperations.GetGenre
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _context;
        public GetGenresQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> genresViewModel = new List<GenresViewModel>();
            foreach (var genre in genres)
            {
                genresViewModel.Add(new GenresViewModel()
                {
                    Id=genre.Id,
                    Name=genre.Name,
                    

                });
            }
            return genresViewModel;
        }
    }


    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
