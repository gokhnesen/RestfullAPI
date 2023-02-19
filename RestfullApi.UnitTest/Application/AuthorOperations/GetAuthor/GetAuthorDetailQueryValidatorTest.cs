using FluentAssertions;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.Operations.AuthorOperations.GetAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.GetAuthor
{
    public class GetAuthorDetailQueryValidatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int id)
        {
            GetAuthorDetailQuery command = new(null, null);
            command.AuthorId = id;
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(-0);
        }


        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetAuthorDetailQuery command = new(null, null);
            command.AuthorId = 1;
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
