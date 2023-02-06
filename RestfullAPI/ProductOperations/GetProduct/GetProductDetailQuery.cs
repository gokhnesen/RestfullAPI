using RestfullAPI.DbOperations;

namespace RestfullAPI.ProductOperations.GetProduct
{
    public class GetProductDetailQuery
    {
        private readonly ProductContext _context;
        public int ProductId { get; set; }
        public GetProductDetailQuery(ProductContext context)
        {
            _context = context;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _context.Products.Where(product => product.Id == ProductId).FirstOrDefault();
            if(product is null)
            {
                throw new InvalidOperationException("Ürün bulunamadı");
            }
            ProductDetailViewModel viewModel = new ProductDetailViewModel();
            viewModel.Id = product.Id;
            viewModel.Name = product.Name;
            viewModel.Description = product.Description;
            viewModel.Price = product.Price;
            return viewModel;

        }
    }

    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

    }
}
