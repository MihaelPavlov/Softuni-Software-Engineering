using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        //ctor tab tab  make a constructor
        //if you use (this.) конкретната инстанация в този клас 
        // all field are private 
        private string name; //field

        private int age; 

        public string Name
        {

            get
            {
                return this.name;
            }
            set

            {
                this.name = value;
            }

        }// properties

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }

        }
       // properties

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age)
            : this()//chaining
        {
            this.age = age;
        }
        public Person(string name, int age)
            : this(age)//this is chaining
        {
            this.name = name;
        }


    }
}
