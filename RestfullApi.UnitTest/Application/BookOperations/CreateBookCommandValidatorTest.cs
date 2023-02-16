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

namespace RestfullApi.UnitTest.Application.BookOperations
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("Dune",0,"1",0)]
        [InlineData("", 0, "0", 0)]

        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,string PublishDate,int genreId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1).ToString(),
                GenreId = genreId
            };
            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Dune",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.ToString(),
                GenreId = 1
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Dune",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.AddYears(-2).ToString(),
                GenreId = 1,
                AuthorId = 1
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
     
    }
}
