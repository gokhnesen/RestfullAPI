using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.Operations.GenreOperations.GetGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.GenreOperations.GetGenre
{
    public class GetGenreDetailQueryValidatorTest: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
     
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int id)
        {
            GetGenresDetailQuery command = new(null, null);
            command.GenreId = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetGenresDetailQuery command = new(null, null);
            command.GenreId = 1;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
