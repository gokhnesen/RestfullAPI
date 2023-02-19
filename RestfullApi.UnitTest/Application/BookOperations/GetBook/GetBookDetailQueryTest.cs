using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Operations.AuthorOperations.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestfullAPI.Operations.AuthorOperations.GetAuthor.GetAuthorDetailQuery;

namespace RestfullApi.UnitTest.Application.BookOperations.GetBook
{
    public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenGivenAuthorIdIsNotValid_Book_ShouldBeReturn()
        {
            GetBookDetailQuery command = new GetBookDetailQuery(_context, _mapper);
            command.BookId = 0;
            FluentActions.Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");


        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldNotBeReturnError()
        {
            //arrange
            GetBookDetailQuery command = new GetBookDetailQuery(_context, _mapper);
            Book model = new Book()
            {
               Title="Hobbit",
               PageCount=1000,
               GenreId=1,
               AuthorId=1,
               PublishDate=new DateTime(1900,1,1),
            };
            _context.Books.Add(model);
            _context.SaveChanges();
            command.BookId = model.Id;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var book = _context.Books.SingleOrDefault(book => book.Id == model.Id);
            book.Should().NotBeNull();
            book.Title.Should().Be(model.Title);
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.AuthorId.Should().Be(model.AuthorId);
            book.GenreId.Should().Be(model.GenreId);
        }

    }
}
