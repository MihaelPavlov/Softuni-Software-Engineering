using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> menu = new Dictionary<string, double>();

            Dictionary<string, double> endMenu = new Dictionary<string, double>();
            string input = Console.ReadLine();
            List<string> names = new List<string>();
           


            while (input != "buy")
            {
                string[] items = input.Split(" ");
                string name = items[0];
                double price = double.Parse(items[1]);
                double quantity = double.Parse(items[2]);
                if (!names.Contains(name))
                {
                    names.Add(name);

                }
                if (!menu.ContainsKey(name))
                {
                    menu.Add(name,price);
                    if (!endMenu.ContainsKey(name))
                    {
                        endMenu.Add(name, quantity);
                        
                    }
                    else
                    {       
                        endMenu[name] += quantity;
                    }
                }
                else
                {
                    
                    menu.Remove(name);
                    menu.Add(name, price);
                    if (!endMenu.ContainsKey(name))
                    {
                        endMenu.Add(name, 0);
                        
                    }
                    
                   
                        endMenu[name] += quantity;
                    
                        
                    
                }
                
                input = Console.ReadLine();
                
                               
            
            }
           
            for (int i = 0; i < endMenu.Count; i++)
            {
                endMenu[names[i]] *= menu[names[i]];

            }
            foreach (var item in endMenu)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
            
           

        }
    }
}
