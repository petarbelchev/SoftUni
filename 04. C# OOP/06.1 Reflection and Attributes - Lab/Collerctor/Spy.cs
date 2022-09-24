using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string nameOfInvestigatedClass)
        {
            var sb = new StringBuilder();

            Type investigatedClass = Type.GetType(nameOfInvestigatedClass);

            MethodInfo[] getMethods = investigatedClass.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.Public | 
                BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("get_"))
                .ToArray();

            MethodInfo[] setMethods = investigatedClass.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("set_"))
                .ToArray();

            foreach (MethodInfo method in getMethods)
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in setMethods)
            {
                ParameterInfo[] parameters = method.GetParameters();

                sb.AppendLine($"{method.Name} will set field of {parameters[0].ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
