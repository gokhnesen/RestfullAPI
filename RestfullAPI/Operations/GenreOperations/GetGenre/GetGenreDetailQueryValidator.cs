using FluentValidation;

namespace RestfullAPI.Operations.GenreOperations.GetGenre
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenresDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(request => request.GenreId).GreaterThan(0);
        }
    }
}
