using _04.WildFarm.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Hen : Bird
    {
        private static List<string> foodForAnimal = new List<string>
        {
           ("Vegetable"),
           ("Fruit"),
           ("Meat"),
           ("Seeds")



        };
        private const double foodFat = 0.35;

        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }
        protected override double FoodFat => 0.35;


        protected override List<string> FoodForAnimal => foodForAnimal;

       

        public override string ProduceSoundForFood()
        {
            return "Cluck";
        }

    }
}
