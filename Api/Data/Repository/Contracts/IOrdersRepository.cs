using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Data.Repository.Contracts
{
    public interface IOrdersRepository
    {
        Task<Orders?> GetByIdAsync(Guid id);
        Task CreateOrderAsync(Orders order);
        Task<Orders?> FindOrderByCartId(Guid cart_id);
    }
}