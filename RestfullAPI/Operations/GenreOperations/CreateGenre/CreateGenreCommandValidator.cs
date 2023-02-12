using FluentValidation;

namespace RestfullAPI.Operations.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(request => request.Model.Name).MinimumLength(4);
        }
    }
}
