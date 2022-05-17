using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeNums = 0;
            int nonPrimeNums = 0;

            while (true)
            {
                string input = Console.ReadLine();
                int currentNum;

                if (input == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {primeNums}");
                    Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNums}");
                    break;
                }
                else
                {
                    currentNum = int.Parse(input);
                }

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                int currentCounter = 0;

                for (int i = 1; i <= currentNum; i++)
                {

                    if (currentNum % i == 0)
                    {
                        currentCounter++;
                    }
                }

                if (currentCounter <= 2)
                {
                    primeNums += currentNum;
                }
                else
                {
                    nonPrimeNums += currentNum;
                }
            }
        }
    }
}
