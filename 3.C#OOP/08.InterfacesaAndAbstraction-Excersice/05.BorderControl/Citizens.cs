using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Citizens : ID , IBuyer
    {
        public Citizens(string name , int age , string id , string birth)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birth;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get ; set ; }
        public string Birthday { get; set; }
        public int Food { get ; set ; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
