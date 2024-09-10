using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class ProductInfoDTO
    {
        public Guid id { get; set; }
        public string product_code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateOnly date { get; set; }
    }
}