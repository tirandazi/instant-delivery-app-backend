using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class OrderSummaryDTO
    {

        public Guid id { get; set; }
        public Guid customer_id { get; set; }
        public string payment_mode { get; set; }
        public string delivery_status { get; set; }
        public decimal total_amount { get; set; }
        public List<CartItemsDTO> cartItems { get; set; }

    }
}