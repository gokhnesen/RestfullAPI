using FluentAssertions;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using RestfullAPI.DbOperations;
using RestfullApi.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfullAPI.Operations.GenreOperations.DeleteGenre;

namespace RestfullApi.UnitTest.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public DeleteGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenNotExistGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Silinicek tür bulunamadı");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeDeleted()
        {
            DeleteGenreCommand request = new DeleteGenreCommand(_context);
            request.GenreId = 1;
            FluentActions.Invoking(() => request.Handle()).Invoke();
            var genre = _context.Books.SingleOrDefault(genre => genre.Id == request.GenreId);
            genre.Should().BeNull();
        }
    }
}
