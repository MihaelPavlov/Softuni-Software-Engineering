using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private readonly MachinesManager manager;
        public Engine()
        {
            this.manager = new MachinesManager();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(" ");
                string command = input[0];
                if (command == "Quit")
                {
                    break;
                }
                try
                {

                    if (command == "HirePilot")
                    {
                        string name = input[1];
                        Console.WriteLine(this.manager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        string pilotReporing = input[1];
                        Console.WriteLine(this.manager.PilotReport(pilotReporing));
                    }
                    else if (command == "ManufactureTank")
                    {
                        string name = input[1];
                        double attackPoints = double.Parse(input[2]);
                        double defensePoint = double.Parse(input[3]);
                        Console.WriteLine(this.manager.ManufactureTank(name, attackPoints, defensePoint));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        string name = input[1];
                        double attackPoints = double.Parse(input[2]);
                        double defensePoint = double.Parse(input[3]);
                        Console.WriteLine(this.manager.ManufactureFighter(name, attackPoints, defensePoint)) ;
                    }
                    else if (command == "MachineReport")
                    {
                        string machineName = input[1];
                        Console.WriteLine(this.manager.MachineReport(machineName));
                    }
                    else if (command == "AggressiveMode")
                    {
                        string fighterName = input[1];
                        Console.WriteLine(this.manager.ToggleFighterAggressiveMode(fighterName));
                    }
                    else if (command == "DefenseMode")
                    {
                        string tankName = input[1];
                        Console.WriteLine(this.manager.ToggleTankDefenseMode(tankName));
                    }
                    else if (command == "Engage")
                    {
                        string pilot = input[1];
                        string machine = input[2];
                        Console.WriteLine(this.manager.EngageMachine(pilot, machine));
                    }
                    else if (command == "Attack")
                    {
                        string attackMachine = input[1];
                        string defendMachine = input[2];
                        Console.WriteLine(this.manager.AttackMachines(attackMachine, defendMachine)) ;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }


            }
        }
    }
}
