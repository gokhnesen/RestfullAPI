using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Interfaces;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute]int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("description")]
        public async Task<IActionResult> GetProductByDescription([FromQuery]string description)
        {
            var product = await _productRepository.GetProductByDescriptionAsync(description);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProducts([FromBody]Product request)
        {
            var product = await _productRepository.AddProduct(request);
            return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, product);
        }

        [HttpPut("update/{productId}")]
        public async Task<ActionResult> UpdateProducts([FromBody]Product request,int productId)
        {
            var product = await _productRepository.UpdateProduct(productId,request);
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProducts(int productId)
        {
            var product = await _productRepository.DeleteProduct(productId);
            return Ok(product);
        }

    }
}
