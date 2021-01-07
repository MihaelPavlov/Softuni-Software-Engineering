using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("./text.txt");
            int counter = 1;

            int counterLetter = 0;
            int counterMarks = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int letterCounter = CountOfLetters(line);
                int marksCounter = CountOfMarks(line);


                lines[i]=$"Line {counter}:{lines[i]} ({letterCounter})({marksCounter}))";
                counter++;


                Console.WriteLine(lines[i]);
            }
            File.WriteAllLines("../../../output.txt", lines );
        }

        private static int CountOfMarks(string line)
        {
            char[] marks = { '-', ',', '.', '!', '?' };
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currentLetter = line[i];
                if (marks.Contains(currentLetter))
                {
                    count++;
                }
            }
            return count;
        }

        static int CountOfLetters(string line)
        {
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currentLetter = line[i];
                if (char.IsLetter(currentLetter))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
