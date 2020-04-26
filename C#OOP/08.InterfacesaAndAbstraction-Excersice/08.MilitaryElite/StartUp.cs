using _08.MilitaryElite.Core;
using _08.MilitaryElite.IO;
using _08.MilitaryElite.IO.Contracts;
using _08.MilitaryElite.Models;

using System;

namespace _08.MilitaryElite
{
    public class StartUp
    {
      public  static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine egine = new Engine(reader,writer);
            egine.Run();
        }
    }
}
