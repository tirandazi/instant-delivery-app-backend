using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Model.DTO
{
    public class CartCreateDTO
    {
        public Guid customer_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

    }
}