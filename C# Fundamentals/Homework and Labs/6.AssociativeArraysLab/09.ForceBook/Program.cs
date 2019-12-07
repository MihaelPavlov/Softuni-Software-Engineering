using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();
            //List<string> list = new List<string>();
            Dictionary<string, string> users = new Dictionary<string, string>();


            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] tokens = input.Split(new string[] { " | ", " -> " },
                    StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("|"))
                {
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);
                        if (!sides.ContainsKey(side))
                        {
                            sides[side] = new List<string>();

                        }
                        if (!sides[side].Contains(user))
                        {
                            sides[side].Add(user);

                        }
                    }
                   




                }
                else if (input.Contains("->"))
                {
                    string side = tokens[1];
                    string user = tokens[0];

                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, side);
                        if (!sides.ContainsKey(side))
                        {
                            sides[side] = new List<string>();
                        }
                        sides[side].Add(user);

                    }
                    else
                    {
                        string previousSide = users[user];
                        sides[previousSide].Remove(user);
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new List<string>());
                        }
                        sides[side].Add(user);
                        users[user] = user;



                    }
                    Console.WriteLine($"{user} joins the {side} side!");

                }




                input = Console.ReadLine();
            }
            foreach (var side in sides
                .Where(s=>s.Value.Count >0)
                .OrderByDescending(r=>r.Value.Count)
                .ThenBy(s=>s.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
