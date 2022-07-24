using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, StudentStats>();

            var bannedStudents = new Dictionary<string, StudentStats>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] studentData = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentData[0];

                if (studentData.Length == 2)
                {
                    var bannedStudent = students.Where(s => s.Key == studentName).First();

                    bannedStudents.Add(bannedStudent.Key, bannedStudent.Value);
                    students.Remove(bannedStudent.Key);
                }
                else
                {
                    string language = studentData[1];
                    int points = int.Parse(studentData[2]);

                    if (!students.ContainsKey(studentName))
                    {
                        students.Add(studentName, new StudentStats(language, points));
                    }
                    else
                    {
                        if (!students[studentName].Languages.ContainsKey(language))
                        {
                            students[studentName].Languages.Add(language, 1);
                        }
                        else
                        {
                            students[studentName].Languages[language]++;
                        }

                        if (students[studentName].Points < points)
                        {
                            students[studentName].Points = points;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var submissions = new Dictionary<string, int>();

            Console.WriteLine("Results:");

            foreach (var student in students.OrderByDescending(s => s.Value.Points).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Points}");

                foreach (var language in student.Value.Languages)
                {
                    if (submissions.ContainsKey(language.Key))
                    {
                        submissions[language.Key] += language.Value;
                    }
                    else
                    {
                        submissions.Add(language.Key, 1);
                    }
                }
            }

            foreach (var student in bannedStudents)
            {
                foreach (var language in student.Value.Languages)
                {
                    if (submissions.ContainsKey(language.Key))
                    {
                        submissions[language.Key] += language.Value;
                    }
                    else
                    {
                        submissions.Add(language.Key, 1);
                    }
                }
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }

    class StudentStats
    {
        public StudentStats(string language, int points)
        {
            Languages.Add(language, 1);
            Points = points;
        }
        public Dictionary<string, int> Languages { get; set; } = new Dictionary<string, int>();
        public int Points { get; set; }
        public override string ToString()
        {
            return $"Lang:{Languages.Count}, Pts:{Points}";
        }
    }
}
