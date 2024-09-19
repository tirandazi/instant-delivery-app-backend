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
        public async Task<IActionResult> GetAllProducts([FromQuery] int page=1,[FromQuery] int limit=10)
        {
            var productsDomain = await _productService.GetAllProductsAsync(page,limit);
            var productHomeDTOs=_mapper.Map<List<ProductHomeDTO>>(productsDomain);
            return Ok(productHomeDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(Guid id)
        {
            var productDomain=await _productService.GetProductByIdAsync(id);
            if (productDomain == null){
                return NotFound();
            }
            return Ok(_mapper.Map<ProductInfoDTO>(productDomain));
        }
    }
}