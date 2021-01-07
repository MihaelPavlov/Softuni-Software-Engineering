using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int count = 0;
            bool haveNegative = false;
            
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {

                    count++;
                    if (count==numbers.Count)
                    {
                        Console.WriteLine("Empty");
                        haveNegative = false;
                        break;
                    }
                      

                }
                else
                {
                    numbers.RemoveAll(i => i < 0);
                    haveNegative = true;
                }
                

                
            }
            
            if(haveNegative)
            {
                numbers.Reverse();
                foreach (var item in numbers)
                {

                    Console.Write(item + " ");
                }
            }
            



        }
    }
}
