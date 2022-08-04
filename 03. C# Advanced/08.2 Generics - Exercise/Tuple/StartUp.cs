using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine().Split();
            string name = firstInput[0] + ' ' + firstInput[1];
            string address = firstInput[2];
            var firstTuple = new Tuple<string, string>(name, address);
            Console.WriteLine(firstTuple);

            string[] secondInput = Console.ReadLine().Split();
            name = secondInput[0];
            int littersOfBeer = int.Parse(secondInput[1]);
            var secondTuple = new Tuple<string, int>(name, littersOfBeer);
            Console.WriteLine(secondTuple);

            string[] thirdInput = Console.ReadLine().Split();
            int integer = int.Parse(thirdInput[0]);
            double @double = double.Parse(thirdInput[1]);
            var thirdTuple = new Tuple<int, double>(integer, @double);
            Console.WriteLine(thirdTuple);
        }
    }
}
