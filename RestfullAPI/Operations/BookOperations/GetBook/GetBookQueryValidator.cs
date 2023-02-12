using FluentValidation;

namespace RestfullAPI.BookOperations.Commands.GetBook
{
    public class GetBookQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(request => request.BookId).GreaterThan(0);
        }
    }
}
