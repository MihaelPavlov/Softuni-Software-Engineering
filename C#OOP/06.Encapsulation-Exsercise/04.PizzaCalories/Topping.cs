using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string typeToping;
        Dictionary<string,double> toppings;

        public Topping(string typeToping , double weight)
        {
            this.TypeToping = typeToping;
            this.Weight = weight;
        }


        public string TypeToping
        {
            get
            {
                return this.typeToping;
            }
            set
            {
                if (!TopingValidator.IsValidToping(value))
                {
                    throw new Exception($"Cannot place {value.ToString()} on top of your pizza.");
                }
                this.typeToping = value;
            }
        }

        private double weight;

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value<1 || value>50)
                {
                    throw new Exception($"{this.TypeToping} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            return (this.weight*2) * TopingValidator.GetTopingValue(this.TypeToping);
        }






    }


     
}
