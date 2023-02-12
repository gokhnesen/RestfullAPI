using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _context;

        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap mevcut");

            }
            book = new Books();
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public int GenreId { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
