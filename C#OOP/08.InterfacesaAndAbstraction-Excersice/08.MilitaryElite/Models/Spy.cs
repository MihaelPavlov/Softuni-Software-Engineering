using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Enumerations;


namespace _08.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, int id,  int codeNumber) 
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}\nCode Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
