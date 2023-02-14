using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(request => request.Model.Title).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(request => request.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(request => request.Model.PublishDate).NotEmpty();
            RuleFor(request => request.Model.GenreId).GreaterThan(0);
            RuleFor(request => request.Model.AuthorId).GreaterThan(0);



        }
    }
}
