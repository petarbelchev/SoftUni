using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfInvestigatedClass, params string[] fieldsNameToInvestigate)
        {
            Type investigatedClass = Type.GetType(nameOfInvestigatedClass);

            Object instanceOfTheClass = Activator.CreateInstance(investigatedClass);

            FieldInfo[] fields = investigatedClass.GetFields(
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic)
                .Where(f => fieldsNameToInvestigate.Contains(f.Name))
                .ToArray();


            var sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {nameOfInvestigatedClass}");

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instanceOfTheClass)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
