using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;


namespace _08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private , ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary) 
            : base(firstName, lastName, id, salary)
        {
            this.privates = new List<ISoldier>();
           
        }


        IReadOnlyCollection<ISoldier> ILieutenantGeneral.Privates => (IReadOnlyCollection<ISoldier>)this.privates;

        public void AddPrivate(ISoldier privates)
        {
            this.privates.Add(privates);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in this.privates)
            {
                sb.AppendLine("  "+item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
