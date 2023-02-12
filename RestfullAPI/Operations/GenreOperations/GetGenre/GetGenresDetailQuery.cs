using RestfullAPI.DbOperations;

namespace RestfullAPI.Operations.GenreOperations.GetGenre
{
    public class GetGenresDetailQuery
    {
        private readonly BookStoreDbContext _context;
        public int GenreId { get; set; }

        public GetGenresDetailQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public GenresDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(genre => genre.Id == GenreId).FirstOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("tür bulunamadı");
            }
            GenresDetailViewModel vm = new GenresDetailViewModel();
            vm.Name = genre.Name;
        
            return vm;
        }

        public class GenresDetailViewModel
        {
            public string Name { get; set; }
        }
            
    }
}
