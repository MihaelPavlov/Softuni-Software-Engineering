using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var uniqueUsername = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                if (!uniqueUsername.ContainsKey(name))
                {
                    uniqueUsername.Add(name,0);

                }
            }

            foreach (var (key,value) in uniqueUsername)
            {
                Console.WriteLine(key);
            }
        }
    }
}
