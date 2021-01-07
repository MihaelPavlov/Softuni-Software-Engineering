using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Tiger : Feline
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Meat")

        };
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }
        protected override double FoodFat => 1.00;
        protected override List<string> FoodForAnimal => foodForAnimal;

        public override string ProduceSoundForFood()
        {
            return "ROAR!!!";
        }
    }
}
