using FluentAssertions;
using FluentValidation;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using RestfullAPI.Operations.GenreOperations.DeleteGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(1)]

        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
