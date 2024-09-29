using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repository.Contracts;
using Api.Model.Domain;
using Api.Service.Contracts;

namespace Api.Service
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository cartRepository;
        private readonly IOrdersRepository ordersRepository;
        public OrderService(ICartRepository cartRepository, IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;

        }
        public async Task<Orders> CreateOrderAsync(Orders orders)
        {
            await ordersRepository.CreateOrderAsync(orders);
            var cart=await cartRepository.FindCartByCustomerId(orders.customer_id);
            await cartRepository.ChangeCartStatusAsync(cart);
            return orders;
        }

        public async Task<Orders?> GetOrderAsync(Guid id)
        {
            return await ordersRepository.GetByIdAsync(id);
        }

    public async Task<Orders?> GetOrderByCartAsync(Guid id)
    {
      return await ordersRepository.FindOrderByCartId(id);
    }
  }
}