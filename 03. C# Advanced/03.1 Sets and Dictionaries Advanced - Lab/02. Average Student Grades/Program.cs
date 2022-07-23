using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._AvStGra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentData = Console.ReadLine().Split();
                string studentName = studentData[0];
                decimal studentGrade = decimal.Parse(studentData[1]);

                if (students.ContainsKey(studentName))
                    students[studentName].Add(studentGrade);
                else
                    students[studentName] = new List<decimal>() { studentGrade };
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (decimal grades in student.Value)
                {
                    Console.Write($"{grades:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
