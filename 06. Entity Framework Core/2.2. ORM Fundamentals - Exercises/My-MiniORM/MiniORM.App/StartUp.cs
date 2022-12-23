using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MiniORM;Integrated Security=true;";

            var context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(new Employee()
            {
                FirstName = "Petar",
                LastName = "Petrov",
                DepartmentId = 1
            });

            context.SaveChanges();

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
