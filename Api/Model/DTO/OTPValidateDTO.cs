using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model.DTO
{
    public class OTPValidateDTO
    {
        public string Phone_number { get; set; }
        public string Otp { get; set; }
    }
}