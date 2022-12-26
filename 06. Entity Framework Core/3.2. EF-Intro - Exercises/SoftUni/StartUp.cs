using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                //Problem 3.
                string result = GetEmployeesFullInformation(context);

                //Problem 4.
                //string result = GetEmployeesWithSalaryOver50000(context);

                //Problem 5.
                //string result = GetEmployeesFromResearchAndDevelopment(context);

                //Problem 6.
                //string result = AddNewAddressToEmployee(context);

                //Problem 7.
                //string result = GetEmployeesInPeriod(context);

                //Problem 8.
                //string result = GetAddressesByTown(context);

                //Problem 9.
                //string result = GetEmployee147(context);

                //Problem 10.
                //string result = GetDepartmentsWithMoreThan5Employees(context);

                //Problem 11.
                //string result = GetLatestProjects(context);

                //Problem 12.
                //string result = IncreaseSalaries(context);

                //Problem 13.
                //string result = GetEmployeesByFirstNameStartingWithSa(context);

                //Problem 14.
                //string result = DeleteProjectById(context);

                //Problem 15.
                //string result = RemoveTown(context);

                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees.OrderBy(e => e.EmployeeId))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new { e.FirstName, e.Salary })
                .Where(e => e.Salary > 50000)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees.OrderBy(e => e.FirstName))
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                    DepartmentName = e.Department
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees
                                            .OrderBy(e => e.Salary)
                                            .ThenByDescending(e => e.FirstName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Employee employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
                employee.Address = new Address
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                context.SaveChanges();
            }

            var last10Addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var a in last10Addresses)
            {
                sb.AppendLine(a);
            }

            return sb.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep =>
                    ep.Project.StartDate.Year >= 2001 &&
                    ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            ProjectEndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                            : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.AllProjects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.ProjectStartDate} - {p.ProjectEndDate}");
                }
            }

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Employees)
                .Include(a => a.Town)
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees");
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var ep in employee.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine(ep.Project.Name);
            }

            return sb.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Employees)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                foreach (var e in d.Employees
                                                .OrderBy(e => e.FirstName)
                                                .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }


            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new string[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                employee.Salary += employee.Salary * 0.12M;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProject = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToArray();
            context.EmployeesProjects.RemoveRange(employeesProject);

            var project = context.Projects.Find(2);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var name in projectNames)
            {
                sb.AppendLine(name);
            }

            return sb.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.TownId == town.TownId)
                .ToArray();

            var addressIds = addresses.Select(a => a.AddressId).ToArray();

            var employees = context.Employees
                .Where(e => e.AddressId != null && addressIds.Contains((int)e.AddressId))
                .ToArray();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addressIds.Length} addresses in Seattle were deleted";
        }
    }
}
