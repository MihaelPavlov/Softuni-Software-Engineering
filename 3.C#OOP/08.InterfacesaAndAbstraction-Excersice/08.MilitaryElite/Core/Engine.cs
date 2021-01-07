using _08.MilitaryElite.Contracts;
using _08.MilitaryElite.Exceptions;
using _08.MilitaryElite.IO.Contracts;
using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
           : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();
            while (input != "End")
            {
                var cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmdArgs, id, firstName, lastName);

                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArgs, id, firstName, lastName);

                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        soldier = AddEngineer(cmdArgs, id, firstName, lastName, salary, corps);
                    }

                    catch (InvalidCorpsException ice)
                    {
                        input = Console.ReadLine();

                        continue;
                    }
                }
                else if (soldierType=="Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        ICommando commando = new Commando(firstName, lastName, id, salary, corps);
                        string[] missionArgs = cmdArgs.Skip(6).ToArray();
                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                            string codename = missionArgs[i];
                            string state = missionArgs[i + 1];
                                IMission mission = new Mission(codename, state);
                                commando.AddMission(mission);

                            }
                            catch (InvalidStateMissionException ex)
                            {

                                continue;
                            }
                        }
                        soldier = commando;
                    }
                    catch (InvalidCorpsException ex)
                    {

                        continue;
                    }

                }
                else if (soldierType=="Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(firstName, lastName, id, codeNumber);
                }


                if (soldier!=null)
                {
                this.soldiers.Add(soldier);

                }


                input = Console.ReadLine();
            }
            foreach (var item in this.soldiers)
            {
               this.writer.WriteLine(item.ToString());
            }
        }

        private static ISoldier AddEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(firstName, lastName, id, salary, corps);
            string[] repairArgs = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hourWorked = int.Parse(repairArgs[i + 1]);
                IRepair repair = new Repair(partName, hourWorked);
                engineer.AddRepair(repair);
            }
            soldier = engineer;
            return soldier;
        }

        private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            LieutenantGeneral general = new LieutenantGeneral(firstName, lastName, id, salary);
            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }
            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(firstName, lastName, id, salary);
            return soldier;
        }
    }
}
