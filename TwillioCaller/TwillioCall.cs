using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwillioCaller
{
    public class TwillioCall
    {
        public static void SMSService(string phone, int code)
        {
            SendSms(phone, code).Wait();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

        static async Task SendSms(string phone, int code)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "AC297c271ef56c987b77ec37e2d3da4206";
            const string authToken = "9ae12edd18e44255eacd5c46bd5d5bf1";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: $"Your code is {code}",
                from: new Twilio.Types.PhoneNumber("+12059472980"),
                to: new Twilio.Types.PhoneNumber(phone)
            );
        
        }

    }
}
