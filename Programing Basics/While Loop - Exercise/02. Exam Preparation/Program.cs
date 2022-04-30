using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int unsatLimit = int.Parse(Console.ReadLine());
            int unsatQuantity = 0;
            int gradeSum = 0;
            int taskQuantity = 0;
            string lastTask = null;

            while (unsatQuantity != unsatLimit)
            {
                string taskName = Console.ReadLine();

                if (taskName == "Enough")
                {
                    Console.WriteLine($"Average score: {gradeSum / (double)taskQuantity:f2}");
                    Console.WriteLine($"Number of problems: {taskQuantity}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    unsatQuantity++;
                }

                if (taskName != "Enough")
                {
                    lastTask = taskName;
                }

                taskQuantity++;
                gradeSum += grade;
            }

            if (unsatQuantity >= unsatLimit)
            {
                Console.WriteLine($"You need a break, {unsatQuantity} poor grades.");
            }
        }
    }
}
