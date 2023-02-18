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
using RestfullAPI.Operations.GenreOperations.CreateGenre;

namespace RestfullApi.UnitTest.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(HAZIRLIK)
            var genre = new Genre() { Name = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", IsActive=true};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreModel() { Name = genre.Name };
            //act & assert(Çalıştırma)
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü mevcut");
            //assert(Doğrulama)
        }
        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            CreateGenreModel model = new CreateGenreModel() { Name = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn"};
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var genre = _context.Genres.SingleOrDefault(genre => genre.Name == model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
          
        }
    }
}
