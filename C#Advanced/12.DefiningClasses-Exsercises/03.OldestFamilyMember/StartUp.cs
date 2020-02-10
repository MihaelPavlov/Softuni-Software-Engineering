using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOfPerson = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                

                listOfPerson.AddMember( new Person(name, age));


               

               
            }
            var oldestMember = listOfPerson.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

        }
    }
}
