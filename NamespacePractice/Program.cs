using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sign Up? press 1");
        Console.WriteLine("Exit? press 0");
        int signUp = Console.Read()-48;

        var rand = new Random();
        int code = rand.Next() % 89999 + 10000;       
        if (signUp == 1)
        {
            Console.WriteLine("Write phone number, (+XYYYZZZZZZZ)");
            Console.Write("where, X - code countru, Y - code operator, Z - phone number: ");
            Console.ReadLine();
            string phone = Console.ReadLine();

            string accountSid = "AC297c271ef56c987b77ec37e2d3da4206";
            string authToken = "9ae12edd18e44255eacd5c46bd5d5bf1";

            TwilioClient.Init(accountSid, authToken);           

            var message = MessageResource.Create(
                body: $"Your code is {code}",
                from: new Twilio.Types.PhoneNumber("+12059472980"),
                to: new Twilio.Types.PhoneNumber(phone)
            );

            Console.Write("Please write code on your cellphone: ");
            string inputCode = Console.ReadLine();

            if (Int32.TryParse(inputCode, out int intCode))
            {
                intCode = Int32.Parse(inputCode);
            }

            if (intCode == code)
            {
                Console.WriteLine("Congatulations, You are sign up!");
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }
        else if(signUp == 0)
        {
            Console.WriteLine("You are left from US!");
        }
    }
}