using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contracts
{
  public  interface ILieutenantGeneral :IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPrivate(ISoldier privates);
    }
}
