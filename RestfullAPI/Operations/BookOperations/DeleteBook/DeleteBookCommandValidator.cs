using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(request => request.BookId).GreaterThan(0);
        }
    }
}
