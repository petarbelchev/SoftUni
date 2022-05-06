using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryNumber = int.Parse(Console.ReadLine()); // 1 ... 20
            string presentationName = null;
            double averGradeSum = 0;
            int presentationsCounter = 0;

            while (true)
            {
                presentationName = Console.ReadLine();

                if (presentationName == "Finish")
                {
                    break;
                }

                double grades = 0;

                for (int i = 1; i <= juryNumber; i++) // chetat se ocenkite na jurito
                {
                    grades += double.Parse(Console.ReadLine()); // ot 2.00 do 6.00
                }

                double averGrade = grades / juryNumber;
                averGradeSum += averGrade;
                presentationsCounter++;
                Console.WriteLine($"{presentationName} - {averGrade:f2}.");
            }

            Console.WriteLine($"Student's final assessment is {averGradeSum / presentationsCounter:f2}.");
        }
    }
}
