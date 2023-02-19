using AutoMapper;
using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.UpdateBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Operations.AuthorOperations.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestfullAPI.Operations.AuthorOperations.GetAuthor.GetAuthorDetailQuery;

namespace RestfullApi.UnitTest.Application.AuthorOperations.GetAuthor
{
    public class GetAuthorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenAuthorIdIsNotValid_Author_ShouldBeReturn()
        {
            GetAuthorDetailQuery command = new GetAuthorDetailQuery(_context,_mapper);
            command.AuthorId = 0;
            FluentActions.Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
               

        }
        [Fact]
        public void WhenValidInputsAreGiven_Author_ShouldNotBeReturnError()
        {
            //arrange
            GetAuthorDetailQuery command = new GetAuthorDetailQuery(_context,_mapper);
            Author model = new Author()
            {
                Name = "Sabahattin",
                Surname = "Ali",
                DateOfBirth = new DateTime(1905, 2, 25)
            };
            _context.Authors.Add(model);
            _context.SaveChanges();
            command.AuthorId = model.Id;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var author = _context.Authors.SingleOrDefault(author => author.Id == model.Id);
            author.Should().NotBeNull();
            author.Name.Should().Be(model.Name);
            author.Surname.Should().Be(model.Surname);
            author.DateOfBirth.Should().Be(model.DateOfBirth);
        }
    }
}
