using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] wagons = new int[int.Parse(Console.ReadLine())];
            int sumOfPeople = 0;

            for (int currWagon = 0; currWagon < wagons.Length; currWagon++)
            {
                wagons[currWagon] = int.Parse(Console.ReadLine());
                sumOfPeople += wagons[currWagon];
            }

            foreach (int currWagon in wagons)
            {
                Console.Write($"{currWagon} ");
            }

            Console.WriteLine();
            Console.WriteLine(sumOfPeople);
        }
    }
}
