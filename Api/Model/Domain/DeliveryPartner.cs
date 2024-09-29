using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Domain
{
    public class DeliveryPartner
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string home_location { get; set; }
        public string availability_status { get; set; }
        public decimal hourly_rate { get; set; }
        public int ratings { get; set; }
    }
}