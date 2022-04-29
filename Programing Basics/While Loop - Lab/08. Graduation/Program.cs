using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double gradeSum = 0;
            int grade = 1;
            bool hasGraduated = true;
            bool hasExcluded = false;

            while (grade <= 12)
            {
                double yearGrade = double.Parse(Console.ReadLine());

                if (yearGrade >= 4)
                {
                    gradeSum += yearGrade;
                    grade++;
                }
                else if (hasExcluded == true)
                {
                    hasGraduated = false;
                    break;
                }
                else
                {
                    hasExcluded = true;
                }
            }

            if (hasGraduated)
            {
                Console.WriteLine($"{name} graduated. Average grade: {gradeSum / 12:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            }
        }
    }
}
