using FluentValidation;

namespace RestfullAPI.ProductOperations.GetProduct
{
    public class GetProductDetailValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailValidator()
        {
            RuleFor(request => request.ProductId).GreaterThan(0);
        }
    }
}
