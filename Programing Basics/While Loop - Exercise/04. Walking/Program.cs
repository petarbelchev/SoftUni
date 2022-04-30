using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            string stepsPerDay = null;
            int stepsCounter = 0;

            while (stepsPerDay != "Going home" && stepsCounter < goal)
            {
                stepsPerDay = Console.ReadLine();

                if (stepsPerDay != "Going home")
                {
                    stepsCounter += int.Parse(stepsPerDay);
                }
            }

            if (stepsPerDay == "Going home")
            {
                stepsCounter += int.Parse(Console.ReadLine());
            }

            if (stepsCounter >= goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCounter - goal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goal - stepsCounter} more steps to reach goal.");
            }
        }
    }
}
