using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public static class TopingValidator
    {
       private static Dictionary<string, double> topings;

        public static bool IsValidToping(string typeToping)
        {
           
                Initialize();
            
            return topings.ContainsKey(typeToping.ToLower());
        }

        public static double GetTopingValue(string type)
        {
            Initialize();
            return topings[type.ToLower()];
        }
        private static void Initialize()
        {
            if (topings!=null)
            {
                return;
            }
            topings = new Dictionary<string, double>();

            topings.Add("meat", 1.2);
            topings.Add("veggies", 0.8);
            topings.Add("cheese", 1.1);
            topings.Add("sauce", 0.9);
        }
    }
}
