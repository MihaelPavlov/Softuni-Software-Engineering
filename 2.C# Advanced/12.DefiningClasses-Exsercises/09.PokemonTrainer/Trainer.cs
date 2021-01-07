using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
   public class Trainer
    {

        public Trainer(string name, int number , int CollectionOfPokemons)
        {
            this.Name = name;
            this.NumberOfBadges = number;
            this.CollectionOfPokemons = CollectionOfPokemons;
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public int CollectionOfPokemons { get; set; }

    }
}
