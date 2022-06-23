using System;

namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            int numLectures = int.Parse(Console.ReadLine());
            int adBonus = int.Parse(Console.ReadLine());
            double biggestBonus = 0;
            int maxAtt = 0;

            for (int currStudent = 1; currStudent <= numStudents; currStudent++)
            {
                int attCurrStudent = int.Parse(Console.ReadLine());
                double currBonus = (double)attCurrStudent / numLectures * (5 + adBonus);

                if (currBonus > biggestBonus)
                {
                    biggestBonus = currBonus;
                    maxAtt = attCurrStudent;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(biggestBonus)}.");
            Console.WriteLine($"The student has attended {maxAtt} lectures.");
        }
    }
}
