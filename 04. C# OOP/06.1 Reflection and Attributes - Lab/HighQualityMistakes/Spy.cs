using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HighQualityMistakes
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

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            var sb = new StringBuilder();

            Type analyzedClass = Type.GetType(investigatedClass);

            FieldInfo[] fields = analyzedClass.GetFields(
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            PropertyInfo[] properties = analyzedClass.GetProperties(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            foreach (PropertyInfo prop in properties)
            {
                if (prop.GetMethod.IsPublic == false)
                {
                    sb.AppendLine($"{prop.GetMethod.Name} have to be public!");
                }

                if (prop.SetMethod.IsPublic == true)
                {
                    sb.AppendLine($"{prop.SetMethod.Name} have to be private!");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
