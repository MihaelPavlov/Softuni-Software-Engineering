using System;

namespace _0._7NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                
                Console.Write(n + " ");
                for (int j = n; j < i; j++)
                {
                    Console.WriteLine(i + " ");
                }

            }
        }
        
    }
}
