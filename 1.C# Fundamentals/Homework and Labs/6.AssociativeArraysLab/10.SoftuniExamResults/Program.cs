using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftuniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            /*GOOD MORNING 
                THIS IS YOUR FIRST STEP FOR TODAY 
                    END THIS TASK*/

            /*first Dictionary <string , int> i need
             first the name  and after this the points  */
            /* and second Dictionary with the programing language
             and the submissionsCount of this Language (how many time is say it)
             */
            // READ the input 
            //split the input "-"
            //make ban command (you remove the person but the submision count stay in total)

            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, List<string>> submissions = new Dictionary<string, List<string>>();



            string input = Console.ReadLine();
            while (input!="exam finished")
            {
                string[] tokens = input.Split("-");
                string name = tokens[0];


                if (tokens[1] == "banned")
                {
                    results.Remove(name);
                }
                else if (!results.ContainsKey(name))
                {
                    string language = tokens[1];
                    int point = int.Parse(tokens[2]);

                    results.Add(name, point);
                    
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, new List<string>());
                    }
                    submissions[language].Add(name);


                }
                else if (results.ContainsKey(name))
                {
                    string language = tokens[1];
                    int point = int.Parse(tokens[2]);
                    int previousPoints = results[name];
                    if (previousPoints<point)
                    {
                        results[name] = point;
                    }
                    submissions[language].Add(name);

                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var result in results.OrderByDescending(x=>x.Value).ThenBy(n=>n.Key))
            {
                
                Console.WriteLine($"{result.Key} | {result.Value}");
            }
            Console.WriteLine("Submissions:");

            foreach (var item in submissions.OrderByDescending(x=>x.Value.Count).ThenBy(l=>l.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Count}");
            }
        }
    }
}
