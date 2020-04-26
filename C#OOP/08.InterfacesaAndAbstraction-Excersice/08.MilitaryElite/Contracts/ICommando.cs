﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
   public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);
        
    }
}
