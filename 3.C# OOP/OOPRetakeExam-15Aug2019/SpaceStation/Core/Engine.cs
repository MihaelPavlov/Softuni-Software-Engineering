using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string type = input[1];
                        string name = input[2];
                        this.writer.WriteLine(controller.AddAstronaut(type,name));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string name = input[1];
                        var itemsToAdd = input.Skip(2);
                        this.writer.WriteLine(controller.AddPlanet(name, itemsToAdd.ToArray()));
                       
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string name = input[1];
                        this.writer.WriteLine(controller.RetireAstronaut(name));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string name = input[1];
                        this.writer.WriteLine(controller.ExplorePlanet(name));
                    }
                    else if(input[0] == "Report")
                    {
                        this.writer.WriteLine(controller.Report()) ;
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
