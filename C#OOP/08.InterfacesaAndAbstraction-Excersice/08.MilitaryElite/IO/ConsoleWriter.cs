using _08.MilitaryElite.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
