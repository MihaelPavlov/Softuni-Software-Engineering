using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Pesho", 20);
           
            Person person2 = new Person();

            person.Name = "Gosho";
            person.Age = 18;

        }
    }
}
