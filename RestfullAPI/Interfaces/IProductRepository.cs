using RestfullAPI.Entities;

namespace RestfullAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByDescriptionAsync(string description);
        Task<Product> UpdateProduct(int productId, Product request);
        Task<Product> DeleteProduct(int productId);
        Task<Product> AddProduct(Product request);

    }
}
