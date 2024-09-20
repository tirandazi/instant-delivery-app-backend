using Microsoft.EntityFrameworkCore;

namespace Api.Model.Domain
{
  [PrimaryKey(nameof(cart_id), nameof(product_id))]
    public class CartItems
    {
      //product_name
        public Guid cart_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }//total price
    }
}