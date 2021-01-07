using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> mission;
        public Commando(string firstName, string lastName, int id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.mission = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.mission;



        public void AddMission(IMission mission)
        {
            this.mission.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
            .AppendLine("Missions:");
            foreach (var item in this.Missions)
            {
                sb.AppendLine("  " + item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
