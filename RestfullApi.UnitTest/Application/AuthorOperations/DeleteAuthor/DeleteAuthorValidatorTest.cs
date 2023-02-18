using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.Operations.AuthorOperations.DeleteAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
     
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorId)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = authorId;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(int authorId)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = authorId;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
