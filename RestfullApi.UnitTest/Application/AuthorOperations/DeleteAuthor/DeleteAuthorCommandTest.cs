using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Operations.AuthorOperations.DeleteAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public DeleteAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenValidInputAreGiven_Author_ShouldBeDeleted()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            var author = new Author() 
            { 
                Name = "TestName_WhenValidInputAreGiven_Author_ShouldBeDeleted", 
                Surname = "", 
                DateOfBirth = DateTime.Now.Date.AddYears(-2) 
            };
            _context.Authors.Remove(author);
            _context.SaveChanges();
            command.AuthorId = author.Id;
            FluentActions.Invoking(() => command.Handle()).Invoke();
            var Author = _context.Authors.SingleOrDefault(author => author.Id == command.AuthorId);
            Author.Should().BeNull();
        }
    }
}
