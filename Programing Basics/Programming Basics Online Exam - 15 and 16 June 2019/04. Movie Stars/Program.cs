using System;

namespace _04._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForActors = double.Parse(Console.ReadLine());
            bool isHaveMoney = true;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "ACTION")
                {
                    break;
                }

                string nameCurrentActor = input;
                double paymentCurrentActor = 0;

                if (nameCurrentActor.Length > 15)
                {
                    paymentCurrentActor = budgetForActors * 0.2;
                }
                else
                {
                    paymentCurrentActor = double.Parse(Console.ReadLine());
                }

                if (budgetForActors >= paymentCurrentActor)
                {
                    budgetForActors -= paymentCurrentActor;
                }
                else
                {
                    Console.WriteLine($"We need {paymentCurrentActor - budgetForActors:f2} leva for our actors.");
                    isHaveMoney = false;
                    break;
                }
            }

            if (isHaveMoney)
            {
                Console.WriteLine($"We are left with {budgetForActors:f2} leva.");
            }
        }
    }
}
