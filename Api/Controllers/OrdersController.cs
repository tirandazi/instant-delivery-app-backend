using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;
using Api.Model.DTO;
using Api.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IProductService productService;
        public OrdersController(IOrderService orderService,ICartService cartService,IProductService productService)
        {
            this.productService = productService;
            this.cartService = cartService;
            this.orderService = orderService;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDTO){
            var order=await orderService.GetOrderByCartAsync(createOrderDTO.cart_id);
            if (order!=null){
                return BadRequest("Already ordered");
            }
            order=new Orders{customer_id=createOrderDTO.customer_id,cart_id=createOrderDTO.cart_id,payment_mode="COD",total_amount=createOrderDTO.total_amount,delivery_status="Pending", store_id=null,delivery_partner_id=null };
            var orderSaved=await orderService.CreateOrderAsync(order);
            return Ok(orderSaved);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder([FromQuery] Guid order_id){
            var order= await orderService.GetOrderAsync(order_id);
            var cart_items=await cartService.GetAllCartItemsAsync(order.cart_id);
            List<CartItemsDTO> cartItemsDTOs = new List<CartItemsDTO>();
            foreach (var item in cart_items)
            {
                var product = await productService.GetProductByIdAsync(item.product_id);
                if (product != null)
                {
                    cartItemsDTOs.Add(new CartItemsDTO { product_id = item.product_id, product_name = product.name, quantity = item.quantity, price = item.price });
                }
            }
            OrderSummaryDTO orderSummary=new OrderSummaryDTO{id=order.id,total_amount=order.total_amount,customer_id=order.customer_id,payment_mode=order.payment_mode,delivery_status=order.delivery_status,cartItems=cartItemsDTOs};
            return Ok(orderSummary);
        }
    }
}