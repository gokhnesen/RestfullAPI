using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestfullAPI.Entities;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
                new Product
                {
                    Id = 1,
                    Name="Samsung S22",
                    Description="Phone".ToLower(),
                    Price=20000
                },
                new Product
                {
                    Id = 2,
                    Name="iPhone 14",
                    Description="Phone".ToLower(),
                    Price=30000
                },
        };


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            if(products == null)
            {
                return StatusCode(500, "Internal server error");
            }
    
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = products.Find(x=>x.Id == id);
            if(product == null)
            {
                return StatusCode(404,"Product not found");
            }
            return Ok(product);
        }
      
        [HttpGet("Description")]
       
        public async Task<ActionResult<Product>> GetProductByDescription(string description)
        {
            var product = products.Find(x => x.Description == description);
            if (product == null)
            {
                return StatusCode(404, "Product not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct([FromBody] Product request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
            {
                return StatusCode(400,"Product not found");
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            return Ok(product);

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProductPatch(int id,[FromBody]JsonPatchDocument<Product> productUpdate)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return StatusCode(400, "Product not found");
            }
            productUpdate.ApplyTo(product,ModelState);
           

            return Ok(product);

        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return StatusCode(400, "Product not found");
            }
            products.Remove(product);
            return Ok(product);


        }
    }
}
