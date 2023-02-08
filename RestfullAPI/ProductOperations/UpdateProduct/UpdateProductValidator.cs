using FluentValidation;

namespace RestfullAPI.ProductOperations.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(request => request.Model.Price).GreaterThan(0);
            RuleFor(request => request.Model.Description).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(request => request.Model.Name).NotEmpty();
        }
    }
}
