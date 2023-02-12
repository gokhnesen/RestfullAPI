using RestfullAPI.DbOperations;

namespace RestfullAPI.BookOperations.Commands.GetBook
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Where(book => book.Id == BookId).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title = book.Title;
            viewModel.Genre = book.GenreId;
            viewModel.PageCount = book.PageCount;
            viewModel.PublishDate = book.PublishDate;
            return viewModel;

        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
