using FluentValidation;

namespace RestfullAPI.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(request => request.GenreId).GreaterThan(0);
        }
    }
}
