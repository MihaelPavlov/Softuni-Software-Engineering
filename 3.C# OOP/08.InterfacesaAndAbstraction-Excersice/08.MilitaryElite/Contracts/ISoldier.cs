using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
   public interface ISoldier
    {
        string FirstName { get; }
        string LastName { get; }
        int Id { get; }
    }
}
