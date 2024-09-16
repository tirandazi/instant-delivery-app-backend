using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.Domain
{
    public class OTPRecord
    {
        public Guid id { get; set; }
        public string phone_number { get; set; }
        public string otp { get; set; }
        public DateTime expiry { get; set; }
        public string secret { get; set; }
    }
}