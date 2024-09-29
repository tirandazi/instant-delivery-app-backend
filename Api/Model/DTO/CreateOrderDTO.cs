using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class CreateOrderDTO
    {
        public Guid customer_id { get; set; }
        public Guid cart_id { get; set; }
        public decimal total_amount { get; set; }
    }
}