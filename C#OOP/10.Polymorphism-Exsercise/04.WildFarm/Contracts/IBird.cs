using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
   public interface IBird : IAnimal
    {
     
        double WingSize { get; }

    }
}
