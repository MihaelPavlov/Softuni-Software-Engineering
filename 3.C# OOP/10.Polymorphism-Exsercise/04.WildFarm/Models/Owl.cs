using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
  public  class Owl : Bird
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Meat")
        };
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }
        protected override double FoodFat => 0.25;
        protected override List<string> FoodForAnimal => foodForAnimal;

        public override string ProduceSoundForFood()
        {
            return "Hoot Hoot";
        }
    }
}
