using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
  public abstract  class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishs;
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishs = new List<IFish>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(d=>d.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishs;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            int capacityIntheMoment = this.fishs.Count;
            if (capacityIntheMoment<this.Capacity)
            {
                this.fishs.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }
        }

        public void Feed()
        {
            foreach (var fish in this.fishs)
            {
                fish.Eat();
            }      
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.name} ({this.GetType().Name})");
            if (this.fishs.Count==0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fishs.Select(f => f.Name))}");
            }
            sb.AppendLine($"Decoration: {this.decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishs.Remove(fish);
        }
    }
}
