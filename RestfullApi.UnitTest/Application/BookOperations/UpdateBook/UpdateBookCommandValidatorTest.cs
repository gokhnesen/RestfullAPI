using FluentAssertions;
using FluentValidation;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.CreateBook;
using RestfullAPI.BookOperations.Commands.UpdateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace RestfullApi.UnitTest.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Dune", 0,0,0)]
        [InlineData("", 0, 0, 0)]

        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId,int authorId)
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                GenreId = genreId,
                AuthorId = authorId
            };
            //act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //assert

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel()
            {
                Title = "Dune",
                PageCount = 1000,
                GenreId = 1,
                AuthorId=1
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel()
            {
                Title = "Dune",
                PageCount = 1000,
                GenreId = 1,
                AuthorId = 1
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
