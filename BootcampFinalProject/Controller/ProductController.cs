using BootcampFinalProject.Models;
using BootcampFinalProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampFinalProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        //method that lists products
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productService.GetAll();
            return Ok(products);
        }

        //Listing products by categoryId
        [HttpGet("category/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var products = productService.GetByCategoryId(categoryId);
            return Ok(products);
        }

        //Listing products by ownerId
        [HttpGet("owner/{ownerId}")]
        public IActionResult GetByOwnerId(int ownerId)
        {
            var products = productService.GetByOwnerId(ownerId);
            return Ok(products);
        }

        //The method by which products are updated
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto model)
        {
            productService.Update(id, model);
            return Ok(new { message = "Product updated successfully" });
        }

        //the method we add new product
        [HttpPost]
        public IActionResult Post(ProductDto model)
        {
            productService.Insert(model);
            return Ok(new { message = "Product posted successful" });
        }

        //method by which products are deleted
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Remove(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
