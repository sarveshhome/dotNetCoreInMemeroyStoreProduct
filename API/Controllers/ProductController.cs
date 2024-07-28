using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Services;
using API.Model;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            _logger.LogInformation("Getting all products");
            return _service.GetProducts();
        }

        ///<summary>Add List of Products</summary>
        /// <remarks>
        ///   Simple request: 
        ///   POST api/products{
        ///      "id": "001",
        ///      "name": "Sony VPCCB Laptop",
        ///      "brand": "Sony"  
        /// }
        /// </remarks>
        /// <param name="Product"></param>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            _logger.LogInformation($"Adding product: {product.Name}");
            _service.AddProduct(product);
            return product;
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(string id, Product product)
        {
            _logger.LogInformation($"Updating product with ID: {id}");
            _service.UpdateProduct(id, product);
            return product;
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _logger.LogInformation($"Deleting product with ID: {id}");
            _service.DeleteProduct(id);
            return id;
        }
    }
}
