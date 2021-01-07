using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Cat : Feline
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Vegetable"),     
           ("Meat")

        };
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        protected override double FoodFat => 0.30;
        protected override List<string> FoodForAnimal => foodForAnimal;

        public override string ProduceSoundForFood()
        {
            return "Meow";
        }
    }
}
