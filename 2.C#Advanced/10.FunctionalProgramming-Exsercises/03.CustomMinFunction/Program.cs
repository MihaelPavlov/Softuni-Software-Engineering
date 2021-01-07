using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
           var numberInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Func<int[],int> function = (arr) => 
            {
                int smallerNumber = int.MaxValue;


                foreach (var item in numberInput)
                {
                    if (item<smallerNumber)
                    {
                        smallerNumber = item;
                    }
                }
                return smallerNumber;
            };
            Console.WriteLine(function(numberInput));

        }
        
       
    }
}
