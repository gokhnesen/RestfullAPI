using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.Operations.GenreOperations.GetGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.BookOperations.GetBook
{
    public class GetBookDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int id)
        {
            GetBookDetailQuery command = new(null, null);
            command.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(-0);
        }


        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetBookDetailQuery command = new(null, null);
            command.BookId = 1;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
