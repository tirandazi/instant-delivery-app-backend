using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class ProductHomeDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}