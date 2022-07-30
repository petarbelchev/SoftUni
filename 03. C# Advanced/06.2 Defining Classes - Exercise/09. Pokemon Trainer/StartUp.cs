using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Trainer
{
    internal class StartUp
    {
        static void Main()
        {
            string cmd;

            var trainers = new List<Trainer>();

            while ((cmd = Console.ReadLine()) != "Tournament")
            {
                string[] pokemontTrainerInfo = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = pokemontTrainerInfo[0];
                string pokemonName = pokemontTrainerInfo[1];
                string pokemonElement = pokemontTrainerInfo[2];
                int pokemonHealth = int.Parse(pokemontTrainerInfo[3]);
                
                var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(trainer => trainer.Name == trainerName))
                {
                    Trainer currTrainer = trainers
                        .First(trainer => trainer.Name == trainerName);

                    currTrainer.ACollectionOfPokemon.Add(newPokemon);
                }
                else
                {
                    trainers.Add(new Trainer(trainerName, newPokemon));
                }                
            }

            while ((cmd = Console.ReadLine()) != "End")
            {
                string givenElement = cmd;

                foreach (var trainer in trainers)
                {
                    if (trainer.ACollectionOfPokemon
                        .Any(pokemon => pokemon.Element == givenElement))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.ACollectionOfPokemon.Count; i++)
                        {
                            trainer.ACollectionOfPokemon[i].Health -= 10;

                            if (trainer.ACollectionOfPokemon[i].Health <= 0)
                            {
                                trainer.ACollectionOfPokemon.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.ACollectionOfPokemon.Count}");
            }
        }
    }
}
