using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;

namespace _08.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string firstName ,string lastName , int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Id { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            return sb.ToString().TrimEnd();
        }
    }
    
}
