using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class UpdateCartDTO
    {
        public Guid product_id { get; set; }
        public Guid customer_id { get; set; }
        public string value { get; set; }
    }
}