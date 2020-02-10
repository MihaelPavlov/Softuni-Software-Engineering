using System;
using System.Collections.Generic;
using System.Linq;


namespace _09.PokemonTrainer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var trainersAndPokemons = new Dictionary<string, List<Pokemon>>();
            var trainers = new HashSet<Trainer>();
            string input = Console.ReadLine();
            while (input!= "Tournament")
            {
                string[] cmdArgs = input.Split();
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    
                    
                if (!trainersAndPokemons.ContainsKey(trainerName))
                {
                    trainersAndPokemons.Add(trainerName, new List<Pokemon>());
                   trainers.Add( new Trainer(trainerName, 0, 0));
                }
                trainersAndPokemons[trainerName].Add(pokemon);
             
                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.CollectionOfPokemons++;
                    }
                }


              
                input = Console.ReadLine();
            }

            string attack = Console.ReadLine();
           
            while (attack!="End")
            {

                foreach (var currTrainer in trainersAndPokemons)
                {
                    bool atLeastOnePokemon = false;
                    foreach (var currPokemon in currTrainer.Value)
                    {
                        if (currPokemon.Element == attack)
                        {
                            trainers.Where(t => t.Name == currTrainer.Key).Select(t=>t.NumberOfBadges++).ToList();                          
                            atLeastOnePokemon = true;
                            break;
                        }
                        
                    }
                    if (!atLeastOnePokemon)
                    {
                        
                        foreach (var currPokemon in currTrainer.Value.ToList())
                        {

                            currPokemon.Health -= 10;
                            if (currPokemon.Health<=0)
                            {
                                 trainersAndPokemons[currTrainer.Key].Remove(currPokemon).ToString();

                                trainers.Where(t=>t.Name == currTrainer.Key).Select(x => x.CollectionOfPokemons==0
                                ? x.CollectionOfPokemons=0 : x.CollectionOfPokemons--).ToList();
                                
                            }
                        }

                    }
                }


                attack = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(t=>t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons}");
                
            }
        }
    }
}
