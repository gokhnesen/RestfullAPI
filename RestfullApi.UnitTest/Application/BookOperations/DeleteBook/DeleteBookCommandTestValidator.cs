using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandTestValidator : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(1)]

        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
     
    }
}
