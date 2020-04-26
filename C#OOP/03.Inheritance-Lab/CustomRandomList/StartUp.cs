using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new RandomList();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");
            list.Add("7");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(list.GetRandomElement());

            }
            Console.WriteLine("Removeed");
   
            Console.WriteLine(list.RemoveRandomString());
            Console.WriteLine(list.RemoveRandomString());
         

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(list.GetRandomElement());

            }
        }
    }
}
