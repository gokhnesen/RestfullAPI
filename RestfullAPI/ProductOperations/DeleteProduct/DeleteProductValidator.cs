using FluentValidation;

namespace RestfullAPI.ProductOperations.DeleteProduct
{
    public class DeleteProductValidator: AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(request => request.ProductId).GreaterThan(0);
        }
    }
}
