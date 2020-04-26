using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Dog : Mammal
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Meat")

        };
        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        protected override double FoodFat => 0.40;
        protected override List<string> FoodForAnimal => foodForAnimal;

        public override string ProduceSoundForFood()
        {
            return "Woof!";
        }
    }
}
