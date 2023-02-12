using FluentValidation;

namespace RestfullAPI.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(request => request.Model.Name).MinimumLength(4);
        }
    }
}
