using FluentAssertions;
using RestfullApi.UnitTest.TestSetup;
using RestfullAPI.Operations.AuthorOperations.CreateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfullApi.UnitTest.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel() 
            { 
                Name = name, 
                Surname = surname, 
                DateOfBirth = DateTime.Now.Date.AddYears(-2) 
            };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
