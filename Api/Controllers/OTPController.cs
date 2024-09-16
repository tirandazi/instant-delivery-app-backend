using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.DTO;
using Api.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;
        private readonly ILogger<OTPController> logger;
        public OTPController(IOTPService otpService,ILogger<OTPController> logger)
        {
            this.logger = logger;
            this._otpService = otpService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateOtp([FromBody] string Phone_number)
        {
            var otp = await _otpService.GenerateOtpAsync(Phone_number);
            return Ok(new { Otp = otp });
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateOtp([FromBody] OTPValidateDTO request)
        {
            var isValid = await _otpService.ValidateOtpAsync(request.Phone_number, request.Otp);

            if (isValid)
            {
                return Ok("OTP is valid");
            }
            return Unauthorized("Invalid or expired OTP");
        }

    }
}