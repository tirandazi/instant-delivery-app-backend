// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Api.Controllers;
// using Api.Service;
// using Microsoft.Extensions.Logging;
// using Moq;

// namespace Test
// {


//         // private ProductService productService;
//         // public ProductControllerTest() {}
//         // [Fact]
//         // public void GetEndPoint_ReturnSuccessStatusCode() {
            
//         // }
    

//     public class ProductControllerTest
//     {
//         private readonly ProductController _controller;
//         private readonly Mock<ILogger<ProductController>> _loggerMock;

//         private readonly Mock<ProductService> _productServiceMock;

//         public ProductControllerTest()
//         {
//             // Setup mock logger or other dependencies here
//             _loggerMock = new Mock<ILogger<ProductController>>();
//             _productServiceMock=new Mock<ProductService>();
//             _controller = new ProductController(_productServiceMock);
//         }

//         [Fact]
//         public async Task Get_ReturnsOkResult_WithListOfEntities()
//         {
//             // Act
//             var result = await _controller.Get();

//             // Assert
//             var okResult = Assert.IsType<OkObjectResult>(result);
//             var returnValue = Assert.IsAssignableFrom<IEnumerable<MyEntity>>(okResult.Value);
//             Assert.NotEmpty(returnValue);
//         }

//         [Fact]
//         public async Task Get_WithInvalidId_ReturnsNotFound()
//         {
//             // Arrange
//             var invalidId = -1;

//             // Act
//             var result = await _controller.Get(invalidId);

//             // Assert
//             Assert.IsType<NotFoundResult>(result);
//         }
//     }
// }
