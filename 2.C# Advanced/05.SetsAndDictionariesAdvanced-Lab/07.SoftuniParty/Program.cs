using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftuniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> listGuests = new HashSet<string>();


            while (input!="PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    listGuests.Add(input);
                }

                
                input = Console.ReadLine();

            }

        //    input = Console.ReadLine();

            while (input!="END")
            {    
                    listGuests.Remove(input);
                    vipGuests.Remove(input);
                
                input = Console.ReadLine();
            }
            Console.WriteLine(listGuests.Count+vipGuests.Count);
            foreach (var item in vipGuests)
            {
                Console.WriteLine(item);
            }
            foreach (var item in listGuests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
