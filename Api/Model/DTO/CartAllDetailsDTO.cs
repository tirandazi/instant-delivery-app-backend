using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class CartAllDetailsDTO
    {
        public Guid id { get; set; }
        public Guid customer_id { get; set; }
        public List<CartItemsDTO> cartItems { get; set; }
        
    }
}