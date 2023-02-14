using FluentValidation;

namespace RestfullAPI.Operations.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(request => request.Model.Surname).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(request => request.Model.DateOfBirth).NotEmpty();

        }
    }
}
