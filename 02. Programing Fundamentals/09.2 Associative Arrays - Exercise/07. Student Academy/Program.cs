using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int pairsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < pairsCount; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (students.ContainsKey(student))
                {
                    students[student].Add(grade);
                }
                else
                {
                    students.Add(student, new List<double>() { grade });
                }
            }

            foreach (var student in students)
            {
                double averageGrade = student.Value.Average();

                if (averageGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
            }
        }
    }
}
