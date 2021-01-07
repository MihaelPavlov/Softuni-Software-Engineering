using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public void Browsing(string websiteAddress)
        {
            Console.WriteLine($"Browsing: {websiteAddress}!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }


    
}
