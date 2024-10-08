using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;
using Api.Service;
using Moq;
using Serilog;
using Xunit;

namespace Test.ServiceTest
{
    public class ProductsServiceTest
    {

        private readonly ProductService _productService;
        private readonly Mock<IProductsRepository> _productRepositoryMock;

        public ProductsServiceTest()
        {
            _productRepositoryMock= new Mock<IProductsRepository>();
            _productService=new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async void GetAllProductsAsync_ReturnsAllProducts()
        {
            var products = new List<Product>
            {
                new Product { id = Guid.Empty, product_code="12345678901", name="test", description="test dummy", price=23, date=DateOnly.FromDateTime(DateTime.Now) },
                new Product { id = Guid.Empty, product_code="12345678901", name="test 2", description="test dummy 2", price=24, date=DateOnly.FromDateTime(DateTime.Now) }
            };
            _productRepositoryMock.Setup(repo => repo.GetAllAsync(1,10)).ReturnsAsync(products);

            // Act
            var result =  await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetProductByIDAsync_ReturnsProduct()
        {
            var product =  new Product { id = Guid.Empty, product_code="12345678901", name="test", description="test dummy", price=23, date=DateOnly.FromDateTime(DateTime.Now) };
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(Guid.Empty)).ReturnsAsync(product);

            // Act
            var result =  await _productService.GetProductByIdAsync(Guid.Empty);

            // Assert
            Assert.NotNull(result);
        
            Assert.Equal(product.id, result.id);
            Assert.Equal(product.product_code, result.product_code);
            Assert.Equal(product.name, result.name);
            Assert.Equal(product.description, result.description);
            Assert.Equal(product.price, result.price);
            Assert.Equal(product.date, result.date);
            
        }
    }
}