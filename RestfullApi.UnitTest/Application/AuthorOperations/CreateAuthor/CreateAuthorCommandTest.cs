using AutoMapper;
using FluentAssertions;
using RestfullAPI.BookOperations.Commands.CreateBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullApi.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;
using RestfullAPI.Operations.AuthorOperations.CreateAuthor;

namespace RestfullApi.UnitTest.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
 
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldBeCreated()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            CreateAuthorModel model = new CreateAuthorModel() 
            {
                Name = "Sabahattin", 
                Surname = "Ali", 
                DateOfBirth = new DateTime(1907,2,25)
            };
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var author = _context.Authors.SingleOrDefault(author => author.Name == model.Name && author.Surname ==model.Surname);
            author.Should().NotBeNull();
            author.Name.Should().Be(model.Name);
            author.Surname.Should().Be(model.Surname);
            author.DateOfBirth.Should().Equals(model.DateOfBirth);
        }
    }
}
