using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            List<string> words = new List<string>();
            string wordsPath = "./words.txt";
            string textPath = "./text.txt";
            string expectedResult = "./expectedResult.txt";
            string actualResult = "./actualRessult";

            using (StreamReader readerWords = new StreamReader(wordsPath))
            {
                string word;

                while ((word = readerWords.ReadLine()) != null)
                {
                    wordCount.Add(word, 0);
                    words.Add(word);
                }
            }

            using (StreamReader readerText = new StreamReader(textPath))
            {
                string line;

                while ((line = readerText.ReadLine()) != null)
                {
                    foreach (string word in words)
                    {
                        string pattern = $"(?<=[^a-zA-Z]){word}(?=[^a-zA-Z])";
                        int count = Regex.Matches(line, pattern, RegexOptions.IgnoreCase).Count;
                        wordCount[word] += count;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(actualResult))
            {
                foreach (var word in wordCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }

            using (StreamWriter writer = new StreamWriter(expectedResult))
            {
                foreach (var word in wordCount.Keys.OrderByDescending(x => wordCount[x]))
                {
                    writer.WriteLine($"{word} - {wordCount[word]}");
                }
            }
        }
    }
}