using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtpGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var otpManager = new ManagerOtp();

            string userId = "SahilYadav";
            string otp = otpManager.GenerateOtp(userId);
            Console.WriteLine($"Generated OTP for {userId}: {otp}");

            Console.WriteLine("Enter the OTP:");

            for (int i = 0; i < 15; i++)  
            {
                string input = Console.ReadLine();
                bool isValid = otpManager.ValidateOtp(userId, input);

                if (isValid)
                {
                    Console.WriteLine("Access granted.");
                    break;
                }

                Thread.Sleep(1000);  
            }

            Console.WriteLine("Session ended.");
        }
    }

}
