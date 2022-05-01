using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsQuantity = int.Parse(Console.ReadLine());
            double gradesSum = 0;
            double to3Counter = 0;
            double to4Counter = 0;
            double to5Counter = 0;
            double to6Counter = 0;

            for (int i = 1; i <= studentsQuantity; i++)
            {
                double input = double.Parse(Console.ReadLine());

                if (input >= 2 && input <= 2.99)
                {
                    to3Counter++;
                    gradesSum += input;
                }
                else if (input >= 3 && input <= 3.99)
                {
                    to4Counter++;
                    gradesSum += input;
                }
                else if (input >= 4 && input <= 4.99)
                {
                    to5Counter++;
                    gradesSum += input;
                }
                else if (input >= 5 && input <= 6)
                {
                    to6Counter++;
                    gradesSum += input;
                }
            }

            double topStudents = (to6Counter / studentsQuantity) * 100;
            double bet45 = (to5Counter / studentsQuantity) * 100;
            double bet34 = (to4Counter / studentsQuantity) * 100;
            double bet23 = (to3Counter / studentsQuantity) * 100;
            double averGrade = gradesSum / studentsQuantity;

            Console.WriteLine($"Top students: {topStudents:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {bet45:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {bet34:f2}%");
            Console.WriteLine($"Fail: {bet23:f2}%");
            Console.WriteLine($"Average: {averGrade:f2}");
        }
    }
}
