using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(request => request.Model.Title).MinimumLength(3).MaximumLength(10);
            RuleFor(request => request.Model.GenreId).GreaterThan(0);
            RuleFor(request => request.Model.PageCount).NotEmpty().GreaterThan(0);
        }

    }
}
