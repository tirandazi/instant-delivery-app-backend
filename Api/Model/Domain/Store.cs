using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Domain
{
    public class Store
    {
        public Guid id { get; set; }
        public string store_name { get; set; }
        public Guid address_id { get; set; }
    }
}