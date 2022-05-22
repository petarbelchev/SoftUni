using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    break;
                }

                double deposit = double.Parse(input);

                if (deposit < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {deposit:f2}");
                balance += deposit;
            }

            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
