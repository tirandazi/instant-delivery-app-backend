using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
// using Api.Model.Domain;

namespace Api.Model.Domain
{
    public class Cart
    {
        public Guid id { get; set; }
        public Guid customer_id { get; set; }
        public string status { get; set; }
        //public List<CartItems> Items { get; set; } = new List<CartItems>();

        // public decimal GetTotalPrice()
        // {
        //     decimal total = 0;
        //     foreach (var item in Items)
        //     {
        //         total += item.price;
        //     }
        //     return total;
        // }
    }
}