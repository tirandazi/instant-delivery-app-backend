using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Data.Repository.Contracts
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        // Task AddAsync(Product product);
        // Task UpdateAsync(Product product);
        // Task DeleteAsync(int id);
    }
}