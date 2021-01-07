using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Pet : ID
    {
        public Pet(string name , string birth)
        {
            this.Name = Name;
            this.Birthday = birth;
        }
        public string Name { get; set; }
        public string Birthday { get ; set ; }
        public string Id { get; set; }
    }
}
