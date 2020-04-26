using _08.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary)
             : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()} Salary: {this.Salary:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
