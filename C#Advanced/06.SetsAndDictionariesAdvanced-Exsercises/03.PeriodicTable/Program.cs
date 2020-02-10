using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var uniqueChemicalElements = new Dictionary<string, string>();


            for (int i = 0; i < n; i++)
            {
                string[] chemicalElements = Console.ReadLine().Split();

                for (int j = 0; j < chemicalElements.Length; j++)
                {
                    string element =chemicalElements[j];

                    if (!uniqueChemicalElements.ContainsKey(element))
                    {
                        uniqueChemicalElements.Add(element,"");

                    }
                }
            
            }

            foreach (var item in uniqueChemicalElements.OrderBy(x=>x.Key))
            {
                Console.Write(item.Key + " ");
            }
        }
    }
}
