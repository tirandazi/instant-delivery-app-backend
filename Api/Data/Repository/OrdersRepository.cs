using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly InstantAppDbContext _context;
        public OrdersRepository(InstantAppDbContext context)
        {
            this._context = context;

        }
        public async Task CreateOrderAsync(Orders order)
        {
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Orders?> GetByIdAsync(Guid id)
        {
            return await _context.orders.FirstOrDefaultAsync(o => o.id==id);
        }

        public async Task<Orders?> FindOrderByCartId(Guid cart_id){
            return await _context.orders.FirstOrDefaultAsync(c => c.cart_id == cart_id);
        }
    }
}