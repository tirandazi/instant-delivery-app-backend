using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model;
using Api.Model.Domain;
using Api.Service.Contracts;

namespace Api.Service
{

  public class ProductService : IProductService
  {
    private readonly IProductsRepository productsRepository;

    public ProductService(IProductsRepository productsRepository)
    {
      this.productsRepository = productsRepository;
    }
    public async Task<List<Product>> GetAllProductsAsync(int pageNumber=1, int pageSize=10)
    {
      return await productsRepository.GetAllAsync(pageNumber,pageSize);
    }

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
      return await productsRepository.GetByIdAsync(id);
    }
  }
}