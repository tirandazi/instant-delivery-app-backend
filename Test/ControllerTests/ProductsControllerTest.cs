using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers;
using Api.Model.Domain;
using Api.Model.DTO;
using Api.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Test.ControllerTests
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IMapper> _mockMapper;

        private readonly ProductController _controller;

        public ProductsControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ProductController(_mockProductService.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new() { id = Guid.Empty, product_code="12345678901", name="test", description="test dummy", price=23, date=DateOnly.FromDateTime(DateTime.Now) },
                new() { id = Guid.Empty, product_code="12345678901", name="test 2", description="test dummy 2", price=24, date=DateOnly.FromDateTime(DateTime.Now) }
            };

            var expectedDTOs = new List<ProductHomeDTO>
            {
                new() { name="test", price=23 },
                new() { name="test 2", price=24 }
            };
            _mockProductService.Setup(service => service.GetAllProductsAsync(1,10)).ReturnsAsync(products);
            _mockMapper.Setup(mapper => mapper.Map<List<ProductHomeDTO>>(products)).Returns(expectedDTOs);

            // Act
            var result = await _controller.GetAllProducts() as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedDTOs, result.Value);
        }

        [Fact]
        public async Task GetProductByID_ReturnsOkResult_WithProduct_WhenIDMatches()
        {
            // Arrange
            var product =  new Product { id = Guid.Empty, product_code="12345678901", name="test", description="test dummy", price=23, date=DateOnly.FromDateTime(DateTime.Now) };


            var expectedDTO = new ProductInfoDTO {id = product.id, product_code="12345678901", name="test", description="test dummy", price=23, date=product.date};
            _mockProductService.Setup(service => service.GetProductByIdAsync(Guid.Empty)).ReturnsAsync(product);
            _mockMapper.Setup(mapper => mapper.Map<ProductInfoDTO>(product)).Returns(expectedDTO);

            // Act
            var result = await _controller.GetProductByID(Guid.Empty) as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedDTO, result.Value);
        }

        [Fact]
        public async Task GetProductByID_ReturnsNotFoundResult_WhenIDDoesntMatches()
        {
            // Arrange
            _mockProductService.Setup(service => service.GetProductByIdAsync(Guid.Empty)).ReturnsAsync((Product)null);

            // Act
            var result = await _controller.GetProductByID(Guid.Empty);
            
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}