using System;

namespace _04._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal centuries = decimal.Parse(Console.ReadLine());
            decimal inYears = centuries * 100;
            decimal inDays = Math.Floor(inYears * 365.2422M);
            decimal inHours = inDays * 24;
            decimal inMinutes = inHours * 60;
            Console.WriteLine($"{centuries} centuries = {inYears} years = {inDays} days = {inHours} hours = {inMinutes} minutes");
        }
    }
}
