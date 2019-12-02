using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Count_Char_in_A_string
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> letters = new Dictionary<char, int>();


            foreach (char letter in input)
            {
                if (letter != ' ')
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters.Add(letter, 0);

                    }
                    letters[letter]++;

                }


            }
            foreach (var item in letters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");

            }

        }
    }
}
