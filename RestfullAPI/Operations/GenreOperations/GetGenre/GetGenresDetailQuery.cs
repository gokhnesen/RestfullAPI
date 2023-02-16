using AutoMapper;
using RestfullAPI.DbOperations;

namespace RestfullAPI.Operations.GenreOperations.GetGenre
{
    public class GetGenresDetailQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenresDetailQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(genre => genre.Id == GenreId).FirstOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("tür bulunamadı");
            }
            GenresDetailViewModel vm = _mapper.Map<GenresDetailViewModel>(genre);
        
            return vm;
        }

        public class GenresDetailViewModel
        {
            public string Name { get; set; }
        }
            
    }
}
