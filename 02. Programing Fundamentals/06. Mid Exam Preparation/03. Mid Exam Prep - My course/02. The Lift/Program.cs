using System;
using System.Linq;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeople = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            const int maxCapacity = 4;

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < maxCapacity && waitingPeople > 0)
                {
                    wagons[i]++;
                    waitingPeople--;
                    i--;
                }
            }

            int peopleOnLift = 0;

            foreach (int wagon in wagons)
            {
                peopleOnLift += wagon;
            }

            bool isFull = (wagons.Length * maxCapacity) == peopleOnLift;

            if (waitingPeople == 0 && !isFull)
            {
                Console.WriteLine("The lift has empty spots!");
            }

            if (waitingPeople > 0 && isFull)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
