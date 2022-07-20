using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int passedCars = 0;
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    int currGreenLightDuration = greenLightDuration;

                    while (currGreenLightDuration > 0 && queue.Count > 0)
                    {
                        string currCar = queue.Dequeue();
                        currGreenLightDuration -= currCar.Length;

                        if (currGreenLightDuration < 0)
                        {
                            if (currGreenLightDuration + freeWindowDuration >= 0)
                            {
                                passedCars++;
                                break;
                            }
                            else
                            {
                                int indexHittedChar = currCar.Length - Math.Abs(currGreenLightDuration + freeWindowDuration);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {currCar[indexHittedChar]}.");
                                
                                return;
                            }
                        }
                        passedCars++;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
