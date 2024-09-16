using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Model.Domain;
using Api.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using OtpNet;
using Serilog;

namespace Api.Service
{
    public class OTPService : IOTPService
    {
        private readonly InstantAppDbContext _context;
        private static readonly TimeSpan OtpExpiryDuration = TimeSpan.FromMinutes(15);
        public OTPService(InstantAppDbContext context)
        {
            this._context = context;
        }
        public async Task<string> GenerateOtpAsync(string Phone_number)
        {
            var secret = KeyGeneration.GenerateRandomKey(20);
            var otp = new Totp(secret).ComputeTotp();
            //var expiry=TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.Local).Add(OtpExpiryDuration);
            var expiry = DateTime.UtcNow.Add(OtpExpiryDuration);
            Log.Information("EXPIRYYYYYYYYYYYYYYYYYYYYYYYYY" + expiry);

            // Remove existing OTPs for the user
            var existingOtp = await _context.otprecord
                .FirstOrDefaultAsync(o => o.phone_number == Phone_number);
            if (existingOtp != null)
            {
                _context.otprecord.Remove(existingOtp);
            }

            // Save new OTP
            var otpRecord = new OTPRecord
            {
                phone_number = Phone_number,
                otp = otp,
                expiry = expiry,
                secret=Convert.ToBase64String(secret)
            };
            _context.otprecord.Add(otpRecord);
            await _context.SaveChangesAsync();

            return otp;
        }
        public async Task<bool> ValidateOtpAsync(string Phone_number, string otp)
        {
            var otpRecord = await _context.otprecord
            .FirstOrDefaultAsync(o => o.phone_number == Phone_number);
            Log.Information(DateTime.UtcNow+"    "+otpRecord.expiry);
            
            if (otpRecord == null || DateTime.UtcNow > otpRecord.expiry)
            {
                return false;
            }

            var secret = Convert.FromBase64String(otpRecord.secret); // Retrieve the same secret used during OTP generation
            var totp = new Totp(secret);
            var isValid = totp.VerifyTotp(otp, out _);
            if (isValid)
            {
                // OTP is valid and expired, remove it
                _context.otprecord.Remove(otpRecord);
                await _context.SaveChangesAsync();
            }

            return isValid;
        }
    }
}