using FluentValidation;

namespace RestfullAPI.Operations.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(request => request.AuthorId).GreaterThan(0);
        }
    }
}
