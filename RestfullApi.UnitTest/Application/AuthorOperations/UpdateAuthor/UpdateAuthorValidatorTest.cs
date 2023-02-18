using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.Operations.AuthorOperations.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorModel() 
            { 
                Name = name, 
                Surname = surname,
                DateOfBirth = DateTime.Now.Date.AddYears(-1) 
            };
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorModel() 
            { 
                Name = "Sabahattin", 
                Surname = "Ali", 
                DateOfBirth = DateTime.Now.Date 
            };
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.AuthorId = 2;
            command.Model = new UpdateAuthorModel() 
            { 
                Name = "Sabahattin", 
                Surname = "Ali", 
                DateOfBirth = new DateTime(1946, 06, 21) 
            };
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
