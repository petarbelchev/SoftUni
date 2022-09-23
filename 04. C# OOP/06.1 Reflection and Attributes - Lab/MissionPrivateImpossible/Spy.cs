using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type investigatedClass = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {investigatedClass.BaseType.Name}");

            MethodInfo[] methods = investigatedClass.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}