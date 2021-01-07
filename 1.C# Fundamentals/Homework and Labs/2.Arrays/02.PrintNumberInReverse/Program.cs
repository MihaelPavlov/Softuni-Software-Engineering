using System;
using System.Linq;

namespace _02.PrintNumberInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[] arr = new int[n];//създааме масив с размер n

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = n-1; i >= 0; i--)//for loop за печатане
            {
                Console.Write(arr[i] + " ");
                
            }

            




        }
    }
}
