using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpGenerator
{
    public class ManagerOtp
    {
        private readonly OtpGenerator _otpGenerator;
        private readonly Dictionary<string, OtpInfo> _otpStorage;

        private const int MaxFailedAttempts = 10;
        private const int OtpValidityDurationInSeconds = 60;

        public ManagerOtp()
        {
            _otpGenerator = new OtpGenerator();
            _otpStorage = new Dictionary<string, OtpInfo>();
        }

        public string GenerateOtp(string userId)
        {
            var otp = _otpGenerator.GenerateOtp();
            var otpInfo = new OtpInfo
            {
                Otp = otp,
                GenerationTime = DateTime.UtcNow,
                FailedAttempts = 0
            };
            _otpStorage[userId] = otpInfo;
            return otp;
        }

        public bool ValidateOtp(string userId, string otp)
        {
            if (!_otpStorage.ContainsKey(userId))
            {
                Console.WriteLine("OTP not generated for this user.");
                return false;
            }

            var otpInfo = _otpStorage[userId];

            if (otpInfo.FailedAttempts >= MaxFailedAttempts)
            {
                Console.WriteLine("Maximum failed attempts reached.");
                return false;
            }

            if ((DateTime.UtcNow - otpInfo.GenerationTime).TotalSeconds > OtpValidityDurationInSeconds)
            {
                Console.WriteLine("OTP has expired.");
                return false;
            }

            if (otpInfo.Otp == otp)
            {
                Console.WriteLine("OTP validated successfully.");
                _otpStorage.Remove(userId);
                return true;
            }

            otpInfo.FailedAttempts++;
            Console.WriteLine($"Invalid OTP. Failed attempts: {otpInfo.FailedAttempts}");
            return false;
        }

        private class OtpInfo
        {
            public string Otp { get; set; }
            public DateTime GenerationTime { get; set; }
            public int FailedAttempts { get; set; }
        }
    }


}