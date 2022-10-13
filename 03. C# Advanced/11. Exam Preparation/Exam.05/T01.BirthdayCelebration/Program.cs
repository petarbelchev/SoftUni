using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var guests = new Queue<int>();
            foreach (var guest in guestsCapacity)
                guests.Enqueue(guest);

            int[] platesCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var plates = new Stack<int>();
            foreach (var plate in platesCapacity)
                plates.Push(plate);

            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int currGuest = guests.Dequeue();
                int currPlate = plates.Pop();

                int result = currGuest - currPlate;

                while (result > 0)
                {
                    currGuest = result;
                    currPlate = plates.Pop();
                    result = currGuest - currPlate;
                }

                wastedFood += Math.Abs(result);
            }

            if (guests.Count == 0)
                Console.WriteLine("Plates: " + string.Join(" ", plates));
            else if (plates.Count == 0)
                Console.WriteLine("Guests: " + string.Join(" ", guests));

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
