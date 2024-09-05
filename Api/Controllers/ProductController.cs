using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.DTO;
using Api.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productsDomain = await _productService.GetAllProductsAsync();
            var productHOmeDTOs=_mapper.Map<List<ProductHomeDTO>>(productsDomain);
            return Ok(productHOmeDTOs);
        }
    }
}