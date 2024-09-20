using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;

namespace Api.Model.DTO
{
    public class CartCreateDTO
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid customer_id { get; set; }
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid product_id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int quantity { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public decimal price { get; set; }

    }
}