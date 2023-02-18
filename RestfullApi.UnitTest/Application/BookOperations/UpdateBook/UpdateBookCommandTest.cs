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
using RestfullAPI.BookOperations.Commands.UpdateBook;

namespace RestfullApi.UnitTest.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = 0;
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Kitap bulunamadı");
        }
        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(_context);
            UpdateBookModel model = new UpdateBookModel() 
            { 
                Title = "Hobbit", 
                PageCount = 1000, 
                GenreId = 1 
            };
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
