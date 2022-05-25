using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int distanceTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int targetsCount = 0;
            int currPokemonPower = pokemonPower;

            while (currPokemonPower >= distanceTargets)
            {
                currPokemonPower -= distanceTargets;
                targetsCount++;

                if (currPokemonPower == (double)pokemonPower / 2 && exhaustionFactor != 0)
                {
                    currPokemonPower /= exhaustionFactor;
                }
            }

            Console.WriteLine(currPokemonPower);
            Console.WriteLine(targetsCount);
        }
    }
}
