using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class CartItemsDTO
    {
        public Guid product_id { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

    }
}