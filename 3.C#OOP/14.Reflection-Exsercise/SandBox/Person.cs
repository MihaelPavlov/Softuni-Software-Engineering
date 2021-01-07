using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SandBox
{
    public class Person
    {
        public Person(string firstName, int age)
        {
            this.FirstName = firstName;
            this.Age = age;
        }
        [Required]
        public string FirstName { get; set; }
        [Range(18,65)]
        public int Age { get; set; }
    }
}
