using RestfullAPI.DbOperations;
using RestfullAPI.Entities;

namespace RestfullAPI.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public  CreateProductModel Model {get;set;}

    private readonly ProductContext _context;

        public CreateProductCommand(ProductContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == Model.Id);
            if(product is not null)
            {
                throw new InvalidOperationException("Ürün mevcut");
              
            }
            product = new Product();
            product.Name = Model.Name;
            product.Description = Model.Description;

            product.Price = Model.Price;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public class CreateProductModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Price { get; set; }
        }
    }
}
