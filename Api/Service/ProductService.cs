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
    public async Task<List<Product>> GetAllProductsAsync()
    {
      return await productsRepository.GetAllAsync();
    }

    public Task<Product?> GetProductByIdAsync(Guid id)
    {
      return productsRepository.GetByIdAsync(id);
    }
  }
}