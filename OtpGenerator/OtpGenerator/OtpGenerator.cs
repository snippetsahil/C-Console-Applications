using System;
using System.Security.Cryptography;

namespace OtpGenerator
{
    public class OtpGenerator
    {
        private readonly RandomNumberGenerator _rng;

        public OtpGenerator()
        {
            _rng = RandomNumberGenerator.Create();
        }

        public string GenerateOtp()
        {
            byte[] bytes = new byte[4];
            _rng.GetBytes(bytes);
            int otp = BitConverter.ToInt32(bytes, 0) % 1000000;
            return Math.Abs(otp).ToString("D6");
        }
    }
}