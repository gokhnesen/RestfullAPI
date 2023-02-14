using FluentValidation;

namespace RestfullAPI.Operations.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {

        public CreateAuthorCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(request => request.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(request => request.Model.DateOfBirth).NotEmpty();
        }
    }
}
