// CartService.cs
using System.Threading.Tasks;
using Api.Model.Domain;
using Api.Data.Repository.Contracts;
using Api.Service.Contracts;
using Serilog;

namespace Api.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemsRepository _cartItemRepository;

        public CartService(ICartRepository cartRepository, ICartItemsRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Cart> CreateCartAsync(Guid customer_id)
        {
            var cart = new Cart { customer_id = customer_id, status = "Pending" };
            await _cartRepository.AddAsync(cart);

            return cart;
        }

        public async Task<Cart> GetCartAsync(Guid id)
        {
            return await _cartRepository.GetByIdAsync(id);
        }

        public async Task AddItemToCartAsync(Guid cartId, CartItems item)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart != null)
            {
                //cart.Items.Add(item);
                await _cartItemRepository.AddAsync(item);
                await _cartRepository.UpdateAsync(cart);
            }
        }

        public async Task RemoveItemFromCartAsync(Guid cart_id, Guid product_id)
        {
            var cart = await _cartRepository.GetByIdAsync(cart_id);
            if (cart != null)
            {
                var item = await _cartItemRepository.GetByIdAsync(cart_id, product_id);
                if (item != null)
                {
                    //cart.Items.Remove(item);
                    await _cartItemRepository.DeleteAsync(cart_id, product_id);
                    await _cartRepository.UpdateAsync(cart);
                }
            }
        }

        // public async Task<decimal> GetCartTotalPriceAsync(Guid cartId)
        // {
        //     var cart = await _cartRepository.GetByIdAsync(cartId);
        //     return cart != null ? cart.GetTotalPrice() : 0;
        // }

        public async Task<Guid?> FindCartByCustomerID(Guid customer_id)
        {
            var cart = await _cartRepository.FindCartByCustomerId(customer_id);
            return cart?.id;
        }
    }
}