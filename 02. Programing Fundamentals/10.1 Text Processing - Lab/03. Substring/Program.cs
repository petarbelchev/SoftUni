using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string textToEdit = Console.ReadLine();

            while (textToEdit.Contains(wordToRemove))
            {
                textToEdit = textToEdit.Replace(wordToRemove, "");
            }

            Console.WriteLine(textToEdit);
        }
    }
}
