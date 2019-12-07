using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> safeProducts = new List<string>();

            

            for (int i = 0; i < n; i++)
            {
                string products = Console.ReadLine();
                safeProducts.Add(products);


                safeProducts.Sort();
            }


            for (int i = 0; i < safeProducts.Count; i++)
            {
                Console.WriteLine($"{i+1} {string.Join("",safeProducts[i])}" );
            }
        }
    }
}
