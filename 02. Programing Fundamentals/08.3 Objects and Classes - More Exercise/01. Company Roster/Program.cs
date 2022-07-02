using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] employeeDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = employeeDetails[0];
                double salary = double.Parse(employeeDetails[1]);
                string department = employeeDetails[2];

                employees.Add(new Employee(name, salary, department));

                if (!departments.Contains(department))
                {
                    departments.Add(department);
                }
            }

            string depWithHighAvSalary = string.Empty;
            double highAverSalary = 0;

            for (int i = 0; i < departments.Count; i++)
            {
                double sumOfDepSalary = 0;
                int employeesCount = 0;

                foreach (Employee employee in employees)
                {
                    if (employee.Department == departments[i])
                    {
                        sumOfDepSalary += employee.Salary;
                        employeesCount++;
                    }
                }

                double averDepSalary = sumOfDepSalary / employeesCount;

                if (averDepSalary > highAverSalary)
                {
                    highAverSalary = averDepSalary;
                    depWithHighAvSalary = departments[i];
                }
            }

            List<Employee> bestDeparment = employees.Where(e => e.Department == depWithHighAvSalary).ToList();

            bestDeparment = bestDeparment.OrderByDescending(e => e.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {depWithHighAvSalary}");
            Console.WriteLine(string.Join(Environment.NewLine, bestDeparment));
        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
}
