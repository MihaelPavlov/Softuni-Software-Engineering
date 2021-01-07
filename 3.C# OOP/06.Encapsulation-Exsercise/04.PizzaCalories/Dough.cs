using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {

        private string flourType;
        private string bakingTech;
        private double weight;
        
        Dictionary<string, double> flourTypes;
        Dictionary<string, double> bakingTechniques;

        public Dough(string flourType, string bakingTechType, double weight)
        {
            this.FlourType = flourType;
            this.BakingTech = bakingTechType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!DoughValidator.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTech
        {
            get
            {
                return this.bakingTech;
            }
            set
            {
                if (!DoughValidator.IsValidBakingTech(value))
                {
                    throw new Exception("Invalid baking tech!");
                }
                this.bakingTech = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value<=1 || value>200)
                {
                    throw new Exception("Dough weight should be in range [1..200].");
                }
                this.weight = value;
            }
        }





        public double GetTotalCalories()
        {
            return (this.Weight * 2) * DoughValidator.GetFlourTypeAsValue(this.FlourType) *
                DoughValidator.GetBakingTechAsValue(this.BakingTech);
        }

    }
}
