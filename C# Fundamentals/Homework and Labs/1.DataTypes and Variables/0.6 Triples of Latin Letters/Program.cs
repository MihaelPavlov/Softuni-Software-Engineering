using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._6_Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        char firstChar = (char)('a' + i);
                        char secondChar = (char)('a' + k);
                        char thirdhar = (char)('a' + j);
                        Console.Write(firstChar);
                        Console.Write(secondChar);
                        Console.WriteLine(thirdhar);
                    }
                }
            }


        }
    }
}
