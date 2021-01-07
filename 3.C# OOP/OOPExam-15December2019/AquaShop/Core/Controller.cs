using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            this.aquariums.Add(aquarium);
            return $"Successfully added {aquarium.GetType().Name}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
            this.decorationRepository.Add(decoration);
            return $"Successfully added {decoration.GetType().Name}.";

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                }
                else
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                }
                else
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal price = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);
            return $"The value of Aquarium {aquariumName} is {price:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);


            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decorationToInsert = this.decorationRepository.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decorationToInsert == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decorationToInsert);
            this.decorationRepository.Remove(decorationToInsert);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            string message = string.Empty;
            foreach (var aquarium in this.aquariums)
            {
               message+= aquarium.GetInfo() ;
            }
            return message;
        }
    }
}
