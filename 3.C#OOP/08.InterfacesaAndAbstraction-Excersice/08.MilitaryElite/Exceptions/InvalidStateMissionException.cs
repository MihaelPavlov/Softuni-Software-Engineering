using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Exceptions
{
    public class InvalidStateMissionException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid mission state!";
        public InvalidStateMissionException()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidStateMissionException(string message) 
            : base(message)
        {
        }
    }
}
