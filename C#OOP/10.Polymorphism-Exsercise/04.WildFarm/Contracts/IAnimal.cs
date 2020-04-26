using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
   public interface IAnimal
    {
        string Name { get;  }
        double Weight { get;  }
        int FoodEaten { get;  }

         void AnimalEat( string food, int quantity);
        string ProduceSoundForFood();
    }
}
