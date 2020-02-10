using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OpinionPoll
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }
        public Person(string name, int age)
            : this(age)
        {
            this.name = name;

        }

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
        }

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
    }

}
