using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> followLike = new Dictionary<string, int>();
            Dictionary<string, int> followComment = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input!="Log out")
            {
                string[] cmdArgs = input.Split(": ");
                string cmd = cmdArgs[0];

                if (cmd=="New follower")
                {
                    string username = cmdArgs[1];

                    if (!followLike.ContainsKey(username))
                    {
                        followLike.Add(username, 0);
                        followComment.Add(username, 0);
                    }
                 
                }
                else if (cmd =="Like")
                {
                    string username = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);
                    if (!followLike.ContainsKey(username))
                    {
                        followLike.Add(username, count);
                        followComment.Add(username, 0);

                    }
                    else
                    {
                        followLike[username] += count;
                    }


                }
                else if (cmd=="Comment")
                {
                    string username = cmdArgs[1];
                    if (!followLike.ContainsKey(username))
                    {
                        followLike.Add(username, 0);
                        followComment.Add(username,1);

                    }
                    else
                    {
                        followComment[username] += 1;
                    }
                }
                else if (cmd=="Blocked")
                {
                    string username = cmdArgs[1];
                    if (followLike.ContainsKey(username))
                    {
                        followLike.Remove(username);
                        followComment.Remove(username);


                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
                input = Console.ReadLine();

            }

            Console.WriteLine(followLike.Count+" followers");
            foreach (var follower in followLike.OrderByDescending(x=>x.Value).ThenBy(b=>b.Key))
            {
                Console.WriteLine($"{follower.Key}: {followComment[follower.Key]+ follower.Value}");


            }


        }
    }
}
