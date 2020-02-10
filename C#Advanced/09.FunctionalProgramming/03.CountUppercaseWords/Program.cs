using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var words = text.Split(new char[] { ' ', ',', '!', '-', '?', ':' },
                StringSplitOptions.RemoveEmptyEntries);
            var capitalWords = words.Where(word => char.IsUpper(word[0]));
            
            foreach (var item in capitalWords)
            {
                Console.WriteLine(item);
            }


        }
    }
}
