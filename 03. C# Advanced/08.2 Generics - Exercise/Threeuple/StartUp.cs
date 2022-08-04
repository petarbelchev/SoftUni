using System;
using System.Text;

namespace Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine().Split();
            string name = firstInput[0] + ' ' + firstInput[1];
            string address = firstInput[2];
            var town = new StringBuilder();
            for (int i = 3; i < firstInput.Length; i++)
            {
                town.Append(firstInput[i] + ' ');
            }
            var firstTuple = new Threeuple<string, string, string>(name, address, town.ToString().TrimEnd());
            Console.WriteLine(firstTuple);

            string[] secondInput = Console.ReadLine().Split();
            name = secondInput[0];
            int littersOfBeer = int.Parse(secondInput[1]);
            bool drunkOrNot = secondInput[2] == "drunk";
            var secondTuple = new Threeuple<string, int, bool>(name, littersOfBeer, drunkOrNot);
            Console.WriteLine(secondTuple);

            string[] thirdInput = Console.ReadLine().Split();
            name = thirdInput[0];
            double accBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            var thirdTuple = new Threeuple<string, double, string>(name, accBalance, bankName);
            Console.WriteLine(thirdTuple);
        }
    }
}
