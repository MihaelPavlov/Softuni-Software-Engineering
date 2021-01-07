using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab._02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(" ").ToList();

            Random rnd = new Random();
            List<string> shuffle = new List<string>();

            foreach (var word in words)
            {
                int newIndex = rnd.Next(0,shuffle.Count);
                shuffle.Insert(newIndex, word);
            }
            foreach (var item in shuffle)
            {
                Console.WriteLine(item);
            }
            
        }
    }
    

}
