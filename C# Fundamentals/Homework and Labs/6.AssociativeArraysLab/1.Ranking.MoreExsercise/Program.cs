using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Ranking.MoreExsercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            //contest - key ,passwod - key

            Dictionary<string, string> examsAndPasswords = new Dictionary<string, string>();
            List<string> passwords = new List<string>();


            //logic
            string input = Console.ReadLine();
            while (input != "end of contests")
            { // First unput  and logic 
                string[] tokens = input.Split(":");
                string contest = tokens[0];
                string password = tokens[1];

                if (!examsAndPasswords.ContainsKey(contest))
                {
                    examsAndPasswords.Add(contest, password);
                    passwords.Add(password);
                }
                input = Console.ReadLine();

            }

            Dictionary<string, Dictionary<string, int>> book = new Dictionary<string, Dictionary<string, int>>();

            string secondInput = Console.ReadLine();
            while (secondInput != "end of submissions")
            {// second input and logic 
                string[] tokens = secondInput.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string name = tokens[2];
                int points = int.Parse(tokens[3]);

                if (examsAndPasswords.ContainsKey(contest))
                {
                    if (examsAndPasswords.ContainsValue(password))
                    {
                        if (!book.ContainsKey(name))
                        {
                            book.Add(name, new Dictionary<string, int>());
                            book[name].Add(contest, points);
                        }
                        else if (book.ContainsKey(name))
                        {
                            if (!book[name].ContainsKey(contest))
                            {
                                book[name].Add(contest, points);
                            }
                            
                        }
                        if (book[name].ContainsKey(contest))
                        {
                            if (book[name][contest] < points)
                            {

                                book[name][contest] = points;
                            }
                        }
                        


                    }
                }


                secondInput = Console.ReadLine();
            }

            foreach (var oneName in book.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{oneName.Key}:");
                foreach (var item in oneName.Value)
                {
                    Console.WriteLine($"#{item}");
                    //foreach (var points in pointAndContest.OrderByDescending(x=>x.Key))
                    //      
                }
            }


            //ouput

            //трябва да пази името
        }
    }
}
