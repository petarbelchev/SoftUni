using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                if (number.Any(ch => char.IsDigit(ch) == false))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
            }

            foreach (var siteUrl in sites)
            {
                if (siteUrl.Any(ch => char.IsDigit(ch)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.Browse(siteUrl);
                }
            }
        }
    }
}
