using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Exceptions
{
    public class InvalidMissionCompleteException : Exception
    {
        private const string DEF_EXC_MSG = "Mission already complete!";
        public InvalidMissionCompleteException()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidMissionCompleteException(string message)
            : base(message)
        {
        }
    }
}
