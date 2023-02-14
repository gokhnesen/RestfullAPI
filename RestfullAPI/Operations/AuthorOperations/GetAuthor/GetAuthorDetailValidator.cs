using FluentValidation;

namespace RestfullAPI.Operations.AuthorOperations.GetAuthor
{
    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(request => request.AuthorId).GreaterThan(0);
        }
    }
}
