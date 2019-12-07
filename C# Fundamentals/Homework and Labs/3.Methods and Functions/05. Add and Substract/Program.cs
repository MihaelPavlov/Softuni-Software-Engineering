using System;

namespace _05._Add_and_Substract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c= int.Parse(Console.ReadLine());

            PrintSum(a, b);
            Substract(a , c);
        }
        static int result = 0;
        static int PrintSum(int a, int b )
        {
            result = a + b;
            return result;
            
        }
        static void Substract( int a , int b)
        {
            result = result - b;
            Console.WriteLine(result);
            
        }
    }
}
