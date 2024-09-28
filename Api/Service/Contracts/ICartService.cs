using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Service.Contracts
{
  public interface ICartService
  {
    Task<Cart> CreateCartAsync(Guid customer_id);
    Task<Cart> GetCartAsync(Guid id);
    Task AddItemToCartAsync(Guid cartId, CartItems item);
    Task RemoveItemFromCartAsync(Guid cartId, Guid itemId);
    // Task<decimal> GetCartTotalPriceAsync(Guid cartId);
    Task<Guid?> FindCartByCustomerID(Guid customer_id);
    Task<List<CartItems>> GetAllCartItemsAsync(Guid cart_id);
    Task IncrementQuantity(Guid cart_id, Guid product_id);
    Task DecrementQuantity(Guid cart_id, Guid product_id);
    Task<bool> FindItemInCart(Guid cart_id,Guid product_id);

  }
}