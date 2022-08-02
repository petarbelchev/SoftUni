using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main()
        {
            EqualityScale<int> numbers = new EqualityScale<int>(5, 5);
            
            Console.WriteLine(numbers.AreEqual());
        }
    }
}
