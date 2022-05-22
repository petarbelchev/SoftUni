using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositValue = double.Parse(Console.ReadLine());
            int termOfTheDeposit = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            double totalAmountDepositPeriod = depositValue + termOfTheDeposit * ((depositValue * annualInterestRate / 100) / 12);

            Console.WriteLine(totalAmountDepositPeriod);
        }
    }
}
