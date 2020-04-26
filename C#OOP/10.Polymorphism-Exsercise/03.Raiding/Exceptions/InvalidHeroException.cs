using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        private const string DEF_INV_MSG = "Invalid hero!";
        public InvalidHeroException()
            :base(DEF_INV_MSG)
        {
        }

        public InvalidHeroException(string message) 
            : base(message)
        {
        }
    }
}
