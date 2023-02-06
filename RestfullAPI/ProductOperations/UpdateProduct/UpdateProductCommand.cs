using RestfullAPI.DbOperations;

namespace RestfullAPI.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        private readonly ProductContext _context;
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }

        public UpdateProductCommand(ProductContext context)
        {
           _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id == ProductId);
            if(product == null)
            {
                throw new InvalidOperationException("Ürün bulunamadı");
            }
            product.Name = Model.Name !=default ?Model.Name:product.Name;
            product.Description = Model.Description != default ? Model.Description : product.Description;
            product.Price = Model.Price != default ? Model.Price : product.Price;

            _context.SaveChanges();
        }
    }

    public class UpdateProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
