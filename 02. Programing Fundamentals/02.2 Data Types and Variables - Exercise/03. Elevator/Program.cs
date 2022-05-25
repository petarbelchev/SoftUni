using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int neededCourses = peopleCount / elevatorCapacity;

            if (peopleCount % elevatorCapacity != 0)
            {
                neededCourses += 1;
            }

            Console.WriteLine(neededCourses);
        }
    }
}
