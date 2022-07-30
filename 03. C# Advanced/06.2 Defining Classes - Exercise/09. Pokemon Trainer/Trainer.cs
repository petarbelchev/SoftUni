using System.Collections.Generic;

namespace _09._Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            ACollectionOfPokemon.Add(pokemon);
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> ACollectionOfPokemon { get; set; } = new List<Pokemon>();
    }
}
