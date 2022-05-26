using System;

namespace _04._Refact_PrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());

            for (int currNumber = 2; currNumber <= lastNumber; currNumber++)
            {
                string isPrime = "true";

                for (int divider = 2; divider < currNumber; divider++)
                {
                    if (currNumber % divider == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", currNumber, isPrime);
            }
        }
    }
}
