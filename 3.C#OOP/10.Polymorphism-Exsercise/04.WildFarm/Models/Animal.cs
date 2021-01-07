using _04.WildFarm.Contracts;
using _04.WildFarm.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name , double weight , int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; private set; }

        public double Weight { get;  set; }

        public int FoodEaten { get;  set; }
        protected virtual double FoodFat { get; }
        protected abstract List<string> FoodForAnimal { get; }


        public virtual void AnimalEat(string food, int quantity)
        {
            if (this.FoodForAnimal.Contains(food))
            {
                this.FoodEaten += quantity;
                this.Weight += quantity * this.FoodFat;
                
            }
            else
            {
                throw new InvalidTypeOfFood($"{this.GetType().Name} does not eat {food}!");
            }
        }

        

        public abstract string ProduceSoundForFood();
    }
}
