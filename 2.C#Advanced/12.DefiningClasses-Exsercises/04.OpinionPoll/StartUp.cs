using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfPeople = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                listOfPeople.Add(new Person(name, age));
            }

            var moreThenThirty = listOfPeople.Where(p => (p.Age > 30)).OrderBy(p=>p.Name).ToList();

            foreach (var persons in moreThenThirty)
            {
                Console.WriteLine($"{persons.Name} - {persons.Age}");
            }
        }
    }
}
