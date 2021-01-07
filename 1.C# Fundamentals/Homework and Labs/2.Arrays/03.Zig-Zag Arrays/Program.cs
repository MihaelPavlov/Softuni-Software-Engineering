using System;
using System.Numerics;
using System.Linq;

namespace _03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrOne = new int[n];
            int[] arrtwo = new int[n];

            for ( int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(separator: " ")
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 ==0)
                {
                    arrOne[i] = nums[0];
                    arrtwo[i] = nums[1];
                }
                else
                {
                    arrOne[i] = nums[1];
                    arrtwo[i] = nums[0];
                }
                  
            }
            Console.WriteLine(string.Join(" ",arrOne) + Environment.NewLine + string.Join(" ", arrtwo));
           
        }
    }
}
