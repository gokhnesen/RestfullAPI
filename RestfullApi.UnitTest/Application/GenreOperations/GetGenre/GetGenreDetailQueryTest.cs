using AutoMapper;
using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Operations.GenreOperations.GetGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.GenreOperations.GetGenre
{
    public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper; 
        }
     
        [Fact]
        public void WhenGivenAuthorIdIsNotValid_Book_ShouldBeReturn()
        {
            GetGenresDetailQuery command = new GetGenresDetailQuery(_context, _mapper);
            command.GenreId = 0;
            FluentActions.Invoking(() => command.Handle()).Should()
                .Throw<InvalidOperationException>().And.Message.Should().Be("Tür bulunamadı");


        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldNotBeReturnError()
        {
            //arrange
            GetGenresDetailQuery command = new GetGenresDetailQuery(_context, _mapper);
            Genre model = new Genre()
            {
               Name="Romance",
               IsActive=true,
            };
            _context.Genres.Add(model);
            _context.SaveChanges();
            command.GenreId = model.Id;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            //assert
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == model.Id);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);

        }
    }
}
