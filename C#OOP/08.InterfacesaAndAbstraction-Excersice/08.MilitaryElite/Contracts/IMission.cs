using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
   public interface IMission
    {
        public string CodeName { get; }
        public StateMission State { get; }
        void CompleteMission(string codeName);

    }
}
