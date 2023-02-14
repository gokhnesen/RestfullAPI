using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.DbOperations;

namespace RestfullAPI.Operations.AuthorOperations.GetAuthor
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(author => author.Id == AuthorId).FirstOrDefault();
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);

            return vm;
        }

        public class AuthorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string DateOfBirth { get; set; }
        }
    }
}
