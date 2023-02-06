using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.DbOperations;
using RestfullAPI.Entities;
using RestfullAPI.Interfaces;
using RestfullAPI.ProductOperations.CreateProduct;
using RestfullAPI.ProductOperations.DeleteProduct;
using RestfullAPI.ProductOperations.GetProduct;
using RestfullAPI.ProductOperations.UpdateProduct;
using static RestfullAPI.ProductOperations.CreateProduct.CreateProductCommand;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductContext context, ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _context = context;
            _logger = logger;
            _productRepository = productRepository;
        }
        [HttpGet]
        public  IActionResult GetProducts()
        {
            _logger.LogInformation("Getting all products");
            GetProductQuery query =  new GetProductQuery(_context); // View model kullanımı
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public  IActionResult GetProductById([FromRoute]int productId)
        {
            ProductDetailViewModel result;
            _logger.LogInformation("Getting product");
            //var product = await _productRepository.GetProductByIdAsync(productId);
            //if(product == null)
            //{
            //    _logger.LogWarning($"Product id {productId} not found");
            //    return StatusCode(404, "Product not found");
            //}
            try
            {
                GetProductDetailQuery query = new GetProductDetailQuery(_context);
                query.ProductId = productId;
                result = query.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
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
        public  IActionResult AddProducts([FromBody]CreateProductModel request)
        {
            _logger.LogInformation("Creating product");
            CreateProductCommand command = new CreateProductCommand(_context);

            try
            {
                command.Model = request;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            //var product = await _productRepository.AddProduct(request);
            //if(product == null)
            //{
            //    return StatusCode(400,"Bad Request");
            //}
            //return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, product);

           
            return Ok();
        }

        [HttpPut("update/{productId}")]
        public IActionResult UpdateProducts([FromBody]UpdateProductModel request,int productId)
        {
            _logger.LogInformation("Updating product");

            try
            {
                UpdateProductCommand command = new UpdateProductCommand(_context);
                command.ProductId = productId;
                command.Model = request;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
         
            return Ok(request);

            //var product = await _productRepository.UpdateProduct(productId,request);
            //if (product == null)
            //{
            //    return StatusCode(400, "Bad Request");
            //}
            //return Ok(product);


        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProducts(int productId)
        {
            _logger.LogInformation("Deleting product");

            try
            {
                DeleteProductCommand command = new DeleteProductCommand(_context);
                command.ProductId = productId;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        
       
            //var product = await _productRepository.DeleteProduct(productId);
            //if (product == null)
            //{
            //    return StatusCode(404, "Product not found");
            //}
            //return Ok(product);
        }

    }
}
