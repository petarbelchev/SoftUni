using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double budget = double.Parse(Console.ReadLine());

                while (budget > 0)
                {
                    budget -= double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
