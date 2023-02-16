using AutoMapper;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.Operations.GenreOperations.GetGenre
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> genresViewModel = _mapper.Map<List<GenresViewModel>>(genres);
    
            return genresViewModel;
        }
    }


    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
