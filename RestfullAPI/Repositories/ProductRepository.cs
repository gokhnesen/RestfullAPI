using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Interfaces;
using System.Net;

namespace RestfullAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product request)
        {
            var product = await _context.Products.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var existProduct = await GetProductByIdAsync(productId);
            if(existProduct != null)
            {
                _context.Products.Remove(existProduct);
                await _context.SaveChangesAsync();
                return existProduct;
            }
            return null;
        }

        public async Task<Product> GetProductByDescriptionAsync(string description)
        {
            return await _context.Products.FirstOrDefaultAsync(x=>x.Description == description);
          
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
            
        }

        public  async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product> UpdateProduct(int productId, Product request)
        {
            var existProduct = await GetProductByIdAsync(productId);
            if(existProduct != null)
            {
                existProduct.Name = request.Name;
                existProduct.Description = request.Description;
                existProduct.Price = request.Price;

                await _context.SaveChangesAsync();
                return existProduct;
            }
            return null;
        }
    }
}
