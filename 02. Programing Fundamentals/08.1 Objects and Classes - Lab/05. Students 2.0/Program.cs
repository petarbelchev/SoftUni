using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] studentInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                int studentAge = int.Parse(studentInfo[2]);
                string studentHomeTown = studentInfo[3];

                Student newStudent = new Student(studentFirstName, studentLastName, studentAge, studentHomeTown);

                if (!IsStudentExist(students, studentFirstName, studentLastName))
                {
                    students.Add(newStudent);
                }
                else
                {
                    OverwriteStudent(students, studentFirstName, studentLastName, studentAge, studentHomeTown);
                }

                input = Console.ReadLine();
            }

            string filterByCity = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == filterByCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static void OverwriteStudent(List<Student> students, string studentFirstName, string studentLastName, int studentAge, string studentHomeTown)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == studentFirstName && student.LastName == studentLastName)
                {
                    student.Age = studentAge;
                    student.HomeTown = studentHomeTown;
                    return;
                }
            }
        }

        static bool IsStudentExist(List<Student> students, string studentFirstName, string studentLastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == studentFirstName && student.LastName == studentLastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}