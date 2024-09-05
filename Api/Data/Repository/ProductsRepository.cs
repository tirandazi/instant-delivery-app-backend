using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
  public class ProductsRepository : IProductsRepository
  {
    private readonly InstantAppDbContext _instantAppDbContext;

    public ProductsRepository(InstantAppDbContext instantAppDbContext)
    {
      _instantAppDbContext = instantAppDbContext;
    }
    public  async Task<List<Product>> GetAllAsync()
    {
        return await _instantAppDbContext.products.ToListAsync();
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
      return _instantAppDbContext.products.FirstOrDefaultAsync(x => x.id == id);
    }
  }
}