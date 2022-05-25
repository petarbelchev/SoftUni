using System;

namespace _06._TriplesofLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int charsCount = 'a' + int.Parse(Console.ReadLine()) - 1;

            for (char firstPosition = 'a'; firstPosition <= charsCount; firstPosition++)
            {
                for (char secondPosition = 'a'; secondPosition <= charsCount; secondPosition++)
                {
                    for (char thirdPosition = 'a'; thirdPosition <= charsCount; thirdPosition++)
                    {
                        Console.WriteLine($"{firstPosition}{secondPosition}{thirdPosition}");
                    }
                }
            }
        }
    }
}
