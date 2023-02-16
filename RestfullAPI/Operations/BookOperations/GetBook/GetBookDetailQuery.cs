using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.BookOperations.Commands.GetBook
{
    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Include(x=>x.Genre).Where(book => book.Id == BookId).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book);
            return viewModel;

        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
