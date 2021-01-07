using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vihicles.Exceptions
{
    public class InvalidFuelException : Exception
    {
        private const string MSG_DEF = "Fuel must be a positive number";
        public InvalidFuelException()
            :base(MSG_DEF)
        {
        }

        public InvalidFuelException(string message) 
            : base(message)
        {
        }
    }
}
