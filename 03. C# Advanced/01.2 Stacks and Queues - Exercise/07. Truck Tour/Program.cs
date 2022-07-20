using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<int> circleOfPumps = new Queue<int>();

            for (int currPump = 0; currPump < numberOfPumps; currPump++)
            {
                int[] currPumpLittersAndDistance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int currPumpPetrolLeft = currPumpLittersAndDistance[0] - currPumpLittersAndDistance[1];

                circleOfPumps.Enqueue(currPumpPetrolLeft);
            }

            int kilometersCounter = 0;

            for (int currPumpIndex = 0; currPumpIndex < circleOfPumps.Count; currPumpIndex++)
            {
                Queue<int> testCircle = new Queue<int>(circleOfPumps);

                while (testCircle.Count > 0)
                {
                    kilometersCounter += testCircle.Dequeue();

                    if (kilometersCounter < 0)
                    {
                        int currPump = circleOfPumps.Dequeue();
                        circleOfPumps.Enqueue(currPump);
                        break;
                    }
                }

                if (kilometersCounter >= 0)
                {
                    Console.WriteLine(currPumpIndex);
                    break;
                }

                kilometersCounter = 0;
            }
        }
    }
}
