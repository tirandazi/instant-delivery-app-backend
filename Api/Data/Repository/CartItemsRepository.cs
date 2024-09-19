using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;

namespace Api.Data.Repository
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly InstantAppDbContext _context;
        public CartItemsRepository(InstantAppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItems> GetByIdAsync(Guid cart_id, Guid product_id)
        {
            return await _context.cart_items.FindAsync(cart_id, product_id);
        }

        public async Task AddAsync(CartItems item)
        {
            await _context.cart_items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItems item)
        {
            _context.cart_items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid cart_id, Guid product_id)
        {
            var item = await GetByIdAsync(cart_id, product_id);
            if (item != null)
            {
                _context.cart_items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}