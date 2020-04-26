using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // RunProgram.Run();

            //  RunProgram.Output();
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> list = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 3)
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    if (!ContainsPeople(list, input[0]))
                    {
                    list.Add(rebel);

                    }
                }
                else if (input.Length == 4)
                {
                    IBuyer citizen = new Citizens(input[0], int.Parse(input[1]), input[2], input[3]);
                    if (!ContainsPeople(list, input[0]))
                    {
                    list.Add(citizen);

                    }
                }
            }
            var command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var man in list)
                {
                    if (man.Name == command)
                    {
                        man.BuyFood();
                    }
                }
                command = Console.ReadLine();
            }

            int sum = list.Sum(x => x.Food);
            Console.WriteLine(sum);
        }
        public static bool ContainsPeople(List<IBuyer> list, string name)
        {
            foreach (var man in list)
            {
                if (man.Name == name)
                { 
                    return true;
                }
            }
            return false;
        }
    }

}
