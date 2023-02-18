using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using RestfullAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public DeleteBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenNotExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Silinicek kitap bulunamadı");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            DeleteBookCommand request = new DeleteBookCommand(_context);
            request.BookId = 1;
            FluentActions.Invoking(() => request.Handle()).Invoke();
            var book   = _context.Books.SingleOrDefault(book=>book.Id == request.BookId);
            book.Should().BeNull();
        }
    }
}
