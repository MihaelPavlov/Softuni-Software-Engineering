using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Exceptions
{
   public class InvalidTypeOfFood : Exception
    {
        private const string DEF_MSG = "Invalid Food";
        public InvalidTypeOfFood()
            :base(DEF_MSG)
        {
        }

        public InvalidTypeOfFood(string message) 
            : base(message)
        {
        }
    }
}
