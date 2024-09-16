using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Domain
{
    public class Customer
    {
        public Guid id { get; set; } 
        public string name { get; set; }
        public string phone_number { get; set; }
        public Guid address_id { get; set; }
    }
}