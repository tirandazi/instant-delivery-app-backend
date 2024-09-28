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
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
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
        public async Task<IActionResult> GetCart([FromQuery] Guid customer_id)
        {
            var cart_id = await _cartService.FindCartByCustomerID(customer_id);
            if (cart_id == null)
            {
                return NotFound("Cart not found for the specified customer.");
            }
            var cart_items = await _cartService.GetAllCartItemsAsync(cart_id.Value);
            List<CartItemsDTO> cartItemsDTOs = new List<CartItemsDTO>();
            foreach (var item in cart_items)
            {
                var product = await _productService.GetProductByIdAsync(item.product_id);
                if (product != null)
                {
                    cartItemsDTOs.Add(new CartItemsDTO { product_id = item.product_id, product_name = product.name, quantity = item.quantity, price = item.price });
                }

            }
            CartAllDetailsDTO cartAllDetailsDTO = new CartAllDetailsDTO { id = cart_id.Value, customer_id = customer_id, cartItems = cartItemsDTOs };
            return Ok(cartAllDetailsDTO);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            // Access parameters from request object
            var product_id = request.product_id;
            var customer_id = request.customer_id;
            var value = request.value;
            var cart_id = await _cartService.FindCartByCustomerID(customer_id);
            if (cart_id == null)
            {
                return NotFound("Cart not found for the specified customer.");
            }
            if (!await _cartService.FindItemInCart(cart_id.Value, product_id))
            {
                return NotFound("Item in cart not found for the specified customer.");
            }
            if (value == "increment")
            {
                await _cartService.IncrementQuantity(cart_id.Value, product_id);
            }
            else if (value == "decrement")
            {
                await _cartService.DecrementQuantity(cart_id.Value, product_id);
            }
            else
            {
                return BadRequest("Illegal value parameter");
            }
            return RedirectToAction("GetCart", new { customer_id = customer_id });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItemFromCart([FromQuery] Guid customer_id, [FromQuery] Guid product_id)
        {
            var cart_id = await _cartService.FindCartByCustomerID(customer_id);
            if (cart_id == null)
            {
                return NotFound("Cart not found for the specified customer.");
            }
            if (! await _cartService.FindItemInCart(cart_id.Value, product_id))
            {
                return NotFound("Item in cart not found for the specified customer.");
            }
            await _cartService.RemoveItemFromCartAsync(cart_id.Value, product_id);
            return Ok(new {message="Item deleted"});

        }
    }
}