using System;
using System.Linq;
using System.Collections.Generic;

namespace PassingFunctionsToMethod
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            /*
4
Nicolas Cage, 20
Mimi, 29
Ico, 31
simo, 16
older
20
Hello, name, age years old
             
          
             */


            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] cmd = input.Split(", ");
                string name = cmd[0];
                int aage = int.Parse(cmd[1]);

                var person = new Person(name, aage);
                people.Add(person);
            }

            var conditionString = Console.ReadLine();
            var conditionParametar = int.Parse(Console.ReadLine());

            Func<Person, bool> predicate = p =>true;//FilteredPeople

            if (conditionString == "older")
            {
                predicate = p => p.Age > conditionParametar;
            }
            else if (conditionString == "younger")
            {
                predicate = p => p.Age < conditionParametar;

            }
            else if (conditionString == "exactly")
            {
                predicate = p => p.Age == conditionParametar;

            }

            var filterePeople = people.Where(predicate);
            var format = Console.ReadLine();
            foreach (var person in filterePeople)
            {
                //the hard way
                var output = format
                    .Replace("age", person.Age.ToString())
                    .Replace("name", person.Name);
                Console.WriteLine(output);

                //the easy way
                //if (format=="name age")
                //{
                //    Console.WriteLine($"{person.Name} - {person.Age}");
                //}
                //else if (format=="name")
                //{
                //    Console.WriteLine($"{person.Name}");
                //}
               
            }


        }
    }
}
