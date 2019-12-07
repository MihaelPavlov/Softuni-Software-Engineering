using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text;

namespace _03.EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"[ ]\:(?<emoji>[a-z]{4,})\:[ ,.!?]";
            string patterSep = @"[ ](?<emojit>:[a-z]{4,}:)[ ,.!?]";

            string input = Console.ReadLine();
            int[] input2 = Console.ReadLine()
                .Split(":")
                .Select(int.Parse)
                .ToArray();
            string st = "";
            bool equalEmoji = false;
            List<string> emojiList = new List<string>();

            Regex emoji = new Regex(patter);
            Regex emojiSeparator = new Regex(patterSep);
            var emojis = emoji.Matches(input);
            int total = 0;
            for (int j = 0; j < input2.Length; j++)
            {
                char symbol = (char)(input2[j]);
                st = st + symbol;
            }

            for (int i = 0; i < emojis.Count; i++)
            {
              

                var separator1 = emojiSeparator.Match(emojis[i].ToString()).Groups["emojit"].Value;

                emojiList.Add(separator1.ToString());
                var firstEmoji = emoji.Match(emojis[i].ToString()).Groups["emoji"].Value;

                for (int b = 0; b < firstEmoji.Length; b++)
                {
                    
                    if (st == firstEmoji)
                    {
                        equalEmoji = true;
                    }
                    char symbol = firstEmoji[b];
                    total += symbol;
                }
            }
            if (equalEmoji == true)
            {
                total = total * 2;
            }
           

            string separator = string.Join(", ", emojiList.SkipLast(0));
            if (emojiList.Count != 0)
            {
                Console.WriteLine($"Emojis found: {separator}");

            }


            Console.WriteLine($"Total Emoji Power: {total}");
        }
    }
}
