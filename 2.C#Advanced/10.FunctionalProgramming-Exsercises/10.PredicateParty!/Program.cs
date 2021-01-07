using System;
using System.Collections.Generic;
using System.Linq;


namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guest = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();


            while (command != "Party!")
            {
                string[] cmdArgs = command.Split(" ").ToArray();
                string cmdType = cmdArgs[0];
                string[] predicateArgs = cmdArgs.Skip(1).ToArray();


                Predicate<string> predicate = GetPredicate(predicateArgs);
                if (cmdType == "Remove")
                {
                    guest.RemoveAll(predicate);
                }
                else if (cmdType== "Double")
                {
                    for (int i = 0; i < guest.Count; i++)
                    {
                        string currGuest = guest[i];

                        if (predicate(currGuest))
                        {
                            guest.Insert(i + 1, currGuest);
                            i++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (guest.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guest)} are going to the party!");

            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string prType = predicateArgs[0];
            string prArg = predicateArgs[1];

            Predicate<string> predicate = null;

            if (prType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prArg);
                });
            }
            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prArg);
                });
            }
            else if (prType == "Length")
            {

                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prArg);
                });
            }
            return predicate;
        }
    }
}
