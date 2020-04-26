using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
   public interface IMammal :IAnimal
    {
         string LivingRegion { get;  }

    }
}
