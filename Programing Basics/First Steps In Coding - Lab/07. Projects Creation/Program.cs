using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberprojects = int.Parse(Console.ReadLine());
            int needHours = numberprojects * 3;
            Console.WriteLine($"The architect {name} will need {needHours} hours to complete {numberprojects} project/s.");
        }
    }
}
