using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {

          Dictionary<string, List<string>> emailUser = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command!="Statistics")
            {
                string[] cmdArgs = command.Split("->");
                string cmd = cmdArgs[0];

                if (cmd=="Add")
                {
                    string username = cmdArgs[1];

                    if (!emailUser.ContainsKey(username))
                    {
                        emailUser.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (cmd == "Send")
                {
                    string username = cmdArgs[1];
                    string email = cmdArgs[2];

                    emailUser[username].Add(email);


                }
                else if (cmd == "Delete")
                {
                    string username = cmdArgs[1];

                    if (emailUser.ContainsKey(username))
                    {
                        emailUser.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");  
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {emailUser.Count}");
            foreach (var item in emailUser.OrderByDescending(x=>x.Value.Count).ThenBy(b=>b.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine($" - {item2}");
                }
            }
            
        }
    }
}
