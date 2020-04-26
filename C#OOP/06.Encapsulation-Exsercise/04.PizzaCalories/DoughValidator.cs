﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;


        public static bool IsValidFlourType(string type)
        {
           
                Initialize();
            

            return flourTypes.ContainsKey(type.ToLower());
        }
        public static bool IsValidBakingTech(string type)
        {
           
                Initialize();
            

            return bakingTechniques.ContainsKey(type.ToLower());
        }

        public static double GetFlourTypeAsValue(string type)
        {
            Initialize();
            return flourTypes[type.ToLower()];
        }

        public static double GetBakingTechAsValue(string type)
        {
            Initialize();
            return bakingTechniques[type.ToLower()];
        }
        private static void Initialize()
        {
            if (flourTypes != null || bakingTechniques != null)
            {
                return;
            }
            flourTypes = new Dictionary<string, double>();
            bakingTechniques = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1.0);
            bakingTechniques.Add("crispy", 0.9);
            bakingTechniques.Add("chewy", 1.1);
            bakingTechniques.Add("homemade", 1.0);

        }
    }

}
