using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int assessorQuantity = int.Parse(Console.ReadLine());

            double actorPoints = academyPoints;

            for (int i = 1; i <= assessorQuantity && actorPoints <= 1250.5; i += 1)
            {
                string assessorName = Console.ReadLine();
                double assessorPoints = double.Parse(Console.ReadLine());
                actorPoints += assessorName.Length * assessorPoints / 2;
            }

            if (actorPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {actorPoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - actorPoints:f1} more!");
            }
        }
    }
}
