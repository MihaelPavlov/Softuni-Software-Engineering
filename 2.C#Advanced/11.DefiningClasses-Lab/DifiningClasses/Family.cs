using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
      

        private string name;
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
        public Family(string name , int age)
        {
            this.name = name;
            this.age = age;
        }
      
        private void AddPerson(string name, int age)
        {
            this.name = name;
            this.age = age;
            
            
        }
        
    }
}
