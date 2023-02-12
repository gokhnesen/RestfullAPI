using RestfullAPI.DbOperations;

namespace RestfullAPI.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;

        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Silinicek kitap bulunamadı");

            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
