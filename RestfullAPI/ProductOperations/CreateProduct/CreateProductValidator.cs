using FluentValidation;

namespace RestfullAPI.ProductOperations.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(request => request.Model.Id).GreaterThan(0);
            RuleFor(request => request.Model.Price).GreaterThan(0);
            RuleFor(request => request.Model.Description).NotEmpty().MinimumLength(3).MaximumLength(10);
            RuleFor(request => request.Model.Name).NotEmpty();
        }
    }
}
