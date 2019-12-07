using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split("&").ToList();

            
            while(true)
            {
                var command = Console.ReadLine();
                var commandParts = command.Split(" ");
                
                if (command == "Finished!")
                {
                    break;
                }

                
                if (commandParts[0] == "Bad" )
                {
                    var kidName = commandParts[1];
                    if (!kids.Contains(kidName))
                    {
                        kids.Insert(0, kidName);
                    }
                }
                else if (commandParts[0] == "Good")
                {
                    var kidName = commandParts[1];
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                    }
                }
                else if (commandParts[0] == "Rename")
                {
                    var kidName = commandParts[1];
                    var newKidName = commandParts[2];
                    if (kids.Contains(kidName))
                    {
                        var indexOfKidName = kids.IndexOf(kidName);
                        kids[indexOfKidName] = newKidName;
                    }
                 
                }
                else if (commandParts[0] == "RearRange")
                {
                    var kidName = commandParts[1];
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                        kids.Add(kidName);
                    }
                }



            }
            Console.WriteLine(string.Join(", ",kids));
        }  
    }
}
