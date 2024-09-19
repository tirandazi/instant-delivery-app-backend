using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Data.Repository.Contracts
{
    public interface ICartItemsRepository
    {
        Task<CartItems> GetByIdAsync(Guid cart_id, Guid product_id);
        Task AddAsync(CartItems item);
        Task UpdateAsync(CartItems item);
        Task DeleteAsync(Guid cart_id,Guid product_id);
    }
}