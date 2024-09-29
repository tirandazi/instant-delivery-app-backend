using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Data.Repository.Contracts
{
    public interface ICartRepository
    {
        Task<Cart> GetByIdAsync(Guid id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(Guid id);
        Task<Cart?> FindCartByCustomerId(Guid id);
        Task ChangeCartStatusAsync(Cart cart);
    }
}