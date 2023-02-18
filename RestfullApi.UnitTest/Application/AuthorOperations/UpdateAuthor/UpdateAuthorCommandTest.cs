using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.DbOperations;
using RestfullAPI.Operations.AuthorOperations.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public UpdateAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenNotExistAuthortIDIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = 0;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Yazar Bulunamadı");
        }
        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            UpdateAuthorModel model = new UpdateAuthorModel()
            { 
                Name = "Sabahattin", 
                Surname = "Ali", 
                DateOfBirth = new DateTime(1905, 2, 25) 
            };
            command.Model = model;
            command.AuthorId = 1;
            FluentActions.Invoking(() => command.Handle()).Invoke();
            var author = _context.Authors.SingleOrDefault(author => author.Id == command.AuthorId);
            author.Should().NotBeNull();
        }
    }
}
