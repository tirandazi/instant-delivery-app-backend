using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Contracts
{
    public interface IOTPService
    {
        Task<string> GenerateOtpAsync(string Phone_number);
        Task<bool> ValidateOtpAsync(string Phone_number, string otp);
    }
}