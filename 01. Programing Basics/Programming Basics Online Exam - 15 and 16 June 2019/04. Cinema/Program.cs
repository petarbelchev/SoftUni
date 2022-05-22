using System;

namespace _04._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            int income = 0;

            while (true)
            {
                string input = Console.ReadLine();
                int currentIncome = 0;

                if (input == "Movie time!")
                {
                    Console.WriteLine($"There are {hallCapacity} seats left in the cinema.");
                    break;
                }

                int currentAudience = int.Parse(input);

                if (hallCapacity >= currentAudience)
                {
                    hallCapacity -= currentAudience;
                    currentIncome = currentAudience * 5;

                    if (currentAudience % 3 == 0)
                    {
                        currentIncome -= 5;
                        income += currentIncome;
                    }
                    else
                    {
                        income += currentIncome;
                    }
                }
                else
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
            }

            Console.WriteLine($"Cinema income - {income} lv.");
        }
    }
}
