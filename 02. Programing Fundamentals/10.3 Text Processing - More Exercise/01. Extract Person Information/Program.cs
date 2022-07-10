using System;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfTexts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfTexts; i++)
            {
                string text = Console.ReadLine();

                int startIndexName = text.IndexOf('@') + 1;
                int endIndexName = text.IndexOf('|');
                string name = text.Substring(startIndexName, endIndexName - startIndexName);

                int startIndexAge = text.IndexOf('#') + 1;
                int endIndexAge = text.IndexOf('*');
                string age = text.Substring(startIndexAge, endIndexAge - startIndexAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
