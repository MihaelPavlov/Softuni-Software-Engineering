using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int collect = 0;

            for (int i = 0; i < n; i++)
            {        
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
                collect += num;
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(collect);
        }
    }
}
