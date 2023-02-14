using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.GetBook
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(request => request.BookId).GreaterThan(0);
        }
    }
}
