using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            MethodInfo[] methods = Type.GetType("AuthorProblem.StartUp")
                .GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.CustomAttributes
                .Any(a => a.AttributeType.Name == "AuthorAttribute"))
                .ToArray();

            foreach (MethodInfo method in methods)
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
