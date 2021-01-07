using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Enumerations;

namespace _08.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(string firstName, string lastName, int id, decimal salary, string corps)
            : base(firstName, lastName, id, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())          
            .AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine("  "+item.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
