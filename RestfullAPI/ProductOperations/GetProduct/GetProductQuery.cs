using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.ProductOperations.GetProduct
{
    public class GetProductQuery
    {
        private readonly ProductContext _dbContext;
        public GetProductQuery(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductsViewModel> Handle()
        {
            var products = _dbContext.Products.OrderBy(x => x.Id).ToList();
            List<ProductsViewModel> vm = new List<ProductsViewModel>();
            foreach (var product in products)
            {
                vm.Add(new ProductsViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                });
            }
            return vm;
        }
    }

    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
