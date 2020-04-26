using _12.SOLID_Excersice.Core;
using _12.SOLID_Excersice.Models.Appenders;
using _12.SOLID_Excersice.Models.Contrcats;
using _12.SOLID_Excersice.Models.Enumarations;
using _12.SOLID_Excersice.Models.Files;
using _12.SOLID_Excersice.Models.Layouts;
using _12.SOLID_Excersice.Models.Loggers;
using System;

namespace _12.SOLID_Excersice
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }

    }
}
