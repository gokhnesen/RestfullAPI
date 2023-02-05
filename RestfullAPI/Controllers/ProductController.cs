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
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            _logger.LogInformation("Getting all products");
            var products = await _productRepository.GetProductsAsync();
            if(products == null)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute]int productId)
        {
            _logger.LogInformation("Getting product");
            var product = await _productRepository.GetProductByIdAsync(productId);
            if(product == null)
            {
                _logger.LogWarning($"Product id {productId} not found");
                return StatusCode(404, "Product not found");
            }
            return Ok(product);
        }

        [HttpGet("description")]
        public async Task<IActionResult> GetProductByDescription([FromQuery]string description)
        {
            var product = await _productRepository.GetProductByDescriptionAsync(description);
            if (product == null)
            {
                _logger.LogWarning($"Product id {description} not found");
                return StatusCode(404,"Product not found");
            }
            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProducts([FromBody]Product request)
        {
            _logger.LogInformation("Creating product");

            var product = await _productRepository.AddProduct(request);
            if(product == null)
            {
                return StatusCode(400,"Bad Request");
            }
            return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, product);
        }

        [HttpPut("update/{productId}")]
        public async Task<ActionResult> UpdateProducts([FromBody]Product request,int productId)
        {
            _logger.LogInformation("Updating product");
            var product = await _productRepository.UpdateProduct(productId,request);
            if (product == null)
            {
                return StatusCode(400, "Bad Request");
            }
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProducts(int productId)
        {
            _logger.LogInformation("Deleting product");
       
            var product = await _productRepository.DeleteProduct(productId);
            if (product == null)
            {
                return StatusCode(404, "Product not found");
            }
            return Ok(product);
        }

    }
}
