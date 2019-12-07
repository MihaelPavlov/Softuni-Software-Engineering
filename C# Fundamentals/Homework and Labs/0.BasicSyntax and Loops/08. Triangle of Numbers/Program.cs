using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <=n; i++)
            {

                Console.WriteLine();
                for (int a = 0; a < i; a++)
                {
                    Console.WriteLine(i + " ");
                    
                }
            }

        }
    }
}
