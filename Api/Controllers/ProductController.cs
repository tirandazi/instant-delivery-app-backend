using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;

        public ProductController(ProductService productService) {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetAllProducts() {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
    }
}