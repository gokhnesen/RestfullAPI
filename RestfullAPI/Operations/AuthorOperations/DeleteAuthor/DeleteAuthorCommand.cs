using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.Operations.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;

        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
            {
                throw new InvalidOperationException("Silinicek yazar bulunamadı");

            }
            if (_context.Books.Any(x=>x.AuthorId==AuthorId))
            {
                throw new InvalidOperationException("Yazarın Kitabı mevcut");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
