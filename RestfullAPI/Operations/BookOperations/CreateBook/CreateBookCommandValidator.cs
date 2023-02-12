using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(request => request.Model.Title).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(request => request.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(request => request.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(request => request.Model.GenreId).GreaterThan(0);



        }
    }
}
