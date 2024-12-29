using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models;
using MyWebApplication.Services.Interfaces;

namespace MyWebApplication.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            if (result == null)
            {
                return NotFound(new { message = $"Product with ID {id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            var existingProduct = _productService.GetProductById(product.ProductID);
            if (existingProduct != null)
            {
                return Conflict(new { message = $"Product with ID {product.ProductID} already exists." });
            }

            var result = _productService.CreateProduct(product);

            if (result == null) {
                return StatusCode(500, new { message = "An error occurred while creating the product." });
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest(new { message = "Product ID in URL does not match the product ID in the body." });
            }

            var result = _productService.UpdateProduct(product);
            if (!result)
            {
                return NotFound(new { message = $"Product with ID {id} not found for update." });
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
            {
                return NotFound(new { message = $"Product with ID {id} not found for deletion." });
            }

            return Ok();
        }
    }
}