using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Service.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync(int pageNumber=1,int pageSize=10);
        Task<Product?> GetProductByIdAsync(Guid id);
    }
}