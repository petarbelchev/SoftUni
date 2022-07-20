using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceEachBullet = int.Parse(Console.ReadLine()); //[0-100]

            int sizeGunBarrel = int.Parse(Console.ReadLine()); //[1-5000]

            int[] bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); //[1-100]
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int[] locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); //[1-100]
            Queue<int> locksQueue = new Queue<int>(locks);

            int valueIntelligence = int.Parse(Console.ReadLine()); //[0 - 100 000]

            int bulletsInBarrel = sizeGunBarrel;

            while (locksQueue.Count > 0)
            {
                int currBullet = bulletsStack.Pop();

                if (currBullet <= locksQueue.Peek())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsInBarrel--;

                if (bulletsInBarrel == 0 && bulletsStack.Count > 0)
                {
                    bulletsInBarrel = sizeGunBarrel;
                    Console.WriteLine("Reloading!");
                }

                valueIntelligence -= priceEachBullet;

                if (bulletsStack.Count == 0 && locksQueue.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");

                    return;
                }                
            }

            Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${valueIntelligence}");
        }
    }
}
