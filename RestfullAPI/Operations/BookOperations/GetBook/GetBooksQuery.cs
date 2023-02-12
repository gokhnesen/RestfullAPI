using RestfullAPI.DbOperations;

namespace RestfullAPI.BookOperations.Commands.GetBook
{
    public class GetBooksQuery
    {
       
            private readonly BookStoreDbContext _dbContext;

            public GetBooksQuery(BookStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public List<BooksViewModel> Handle()
            {
                var books = _dbContext.Books.OrderBy(x => x.Id).ToList();
                List<BooksViewModel> vm = new List<BooksViewModel>();
                foreach (var book in books)
                {
                    vm.Add(new BooksViewModel()
                    {
                        Id = book.Id,
                     Title = book.Title,
                     Genre = book.GenreId,
                     PageCount = book.PageCount,
                     PublishDate = book.PublishDate,
                    });
                }
                return vm;
            }
        }

        public class BooksViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Genre { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    
}
