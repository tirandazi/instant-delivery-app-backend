using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Service.Contracts;
using Api.Model.DTO;
using Api.Model.Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            this._cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAndAddToCart([FromBody] CartCreateDTO cartCreateDTO)
        {
            //var cart_items=cartCreateDTO.cart_items?;
            var cart_id = await _cartService.FindCartByCustomerID(cartCreateDTO.customer_id);

            if (cart_id == null)
            {
                var newCart = await _cartService.CreateCartAsync(cartCreateDTO.customer_id);
                cart_id = newCart.id;
            }
            var cartItem = new CartItems { cart_id = cart_id.Value, product_id = cartCreateDTO.product_id, quantity = cartCreateDTO.quantity, price = cartCreateDTO.price };
            await _cartService.AddItemToCartAsync(cart_id.Value, cartItem);
            var cart_items = await _cartService.GetCartAsync(cart_id.Value);
            return Ok(cart_items);
        }

        [HttpGet]
        public async Task<IActionResult> GetCart([FromQuery] Guid customer_id){
            var cart_id=await _cartService.FindCartByCustomerID(customer_id);
            var cart_items= await _cartService.GetAllCartItemsAsync(cart_id.Value);
            return Ok(cart_items);
        }
    }
}