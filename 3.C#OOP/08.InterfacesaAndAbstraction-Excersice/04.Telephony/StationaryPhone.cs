using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04.Telephony
{
    public class StationaryPhone : ICallable
    {


        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
