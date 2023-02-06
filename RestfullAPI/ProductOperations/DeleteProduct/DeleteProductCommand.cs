using RestfullAPI.DbOperations;

namespace RestfullAPI.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        private readonly ProductContext _context;

        public int ProductId { get; set; }

        public DeleteProductCommand(ProductContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == ProductId);
            if(product == null)
            {
                throw new InvalidOperationException("Silinicek ürün bulunamadı");

            }   
            
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
