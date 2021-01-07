using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Enumerations;
using _08.MilitaryElite.Exceptions;

namespace _08.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName , string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseStateMission(state);
        }
        public string CodeName { get ; private set; }
        public StateMission State { get; private set; }

        public void CompleteMission(string codeName)
        {
            if (this.State== StateMission.Fineshed)
            {
                throw new InvalidMissionCompleteException();
            }
            this.State = StateMission.Fineshed;
        }
        private StateMission TryParseStateMission(string stateStr)
        {
            StateMission mission;
            bool parsed = Enum.TryParse<StateMission>(stateStr, out mission);
            if (!parsed)
            {
                throw new InvalidStateMissionException();
            }
            return mission;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");
           
            return sb.ToString().TrimEnd();
        }
    }
}
