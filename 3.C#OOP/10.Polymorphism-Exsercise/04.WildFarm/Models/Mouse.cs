using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Mouse : Mammal
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Vegetable"),
           ("Fruit"),

        };
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        protected override double FoodFat => 0.10;
        protected override List<string> FoodForAnimal => foodForAnimal;

        public override string ProduceSoundForFood()
        {
            return "Squeak";
        }


    }
}
