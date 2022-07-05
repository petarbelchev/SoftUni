using System;
using System.Collections.Generic;

namespace _08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = cmdArgs[0];
                string employeeId = cmdArgs[1];
                if (companies.ContainsKey(company))
                {
                    if (!companies[company].Contains(employeeId))
                    {
                        companies[company].Add(employeeId);
                    }
                }
                else
                {
                    companies.Add(company, new List<string>() { employeeId });
                }
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var employeeId in company.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}
