using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly InstantAppDbContext _context;

        public CartRepository(InstantAppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            var cart = await _context.cart.Include(c => c.Items).FirstOrDefaultAsync(c => c.id == id);
            return cart;
        }

        public async Task AddAsync(Cart cart)
        {
            await _context.cart.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.cart.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cart = await GetByIdAsync(id);
            if (cart != null)
            {
                _context.cart.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart> FirstOrDefaultAsync(Expression<Func<Cart, bool>> predicate)
        {
            return await _context.cart.FirstOrDefaultAsync(predicate);
        }
    }
}