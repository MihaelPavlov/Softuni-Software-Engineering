using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace _04.PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toping;
        private string name;
        public Pizza(string name , Dough dough)
        {
            this.toping = new List<Topping>();
            this.Name = name;
            this.Dough = dough;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length<1 || value.Length>15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int TopingCount => this.toping.Count;
        
        public Dough Dough { get; }

        public double TotalCalories()
        {
            double totalTopingCalories = this.toping.Sum(x=>x.GetTotalCalories());
           
            return totalTopingCalories + this.Dough.GetTotalCalories();
        }
        public void AddToping(Topping toping)
        {
            if (this.TopingCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.toping.Add(toping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {TotalCalories():F2} Calories.";
        }
    }

}
