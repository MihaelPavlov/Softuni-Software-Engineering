using System;

namespace _01.Person
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person person = null;
            if (age<=15 && age>0)
            {
                person= new Child(name, age);
            }
            else if(age>15 && age>0)
            {
                person = new Person(name, age);
            }
            Console.WriteLine(person);
       
            
         
        }
    }
}
