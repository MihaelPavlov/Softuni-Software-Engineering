﻿using System;

namespace TextProcessing_And_RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            while (input!= "end")
            {
                
                string reverse = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    
                    reverse += input[i];
                    

                }
                Console.WriteLine($"{input} = {reverse}");
                input = Console.ReadLine();

            }
            


            
        }
    }
}
