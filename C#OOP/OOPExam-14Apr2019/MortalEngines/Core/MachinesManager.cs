namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IPilot> pilots;
        private readonly IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            bool isCreated = this.pilots.Any(p => p.Name == name);
            if (isCreated)
            {
                return $"Pilot {name} is hired already";
            }
            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            bool isCreated = this.machines.Any(m => m.GetType().Name == "Tank" 
            && m.Name==name);
            if (isCreated)
            {
                return $"Machine {name} is manufactured already";
            }
            ITank tank = new Tank(name, attackPoints, defensePoints); ;
            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            bool isCreated = this.machines.Any(m => m.GetType().Name=="Fighter" 
            && m.Name== name);
            if (isCreated)
            {
                return $"Machine {name} is manufactured already";
            }
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);
            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot==null )
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            if (machine==null)
            {
                return $"Machine {selectedMachineName} could not be found";

            }
            bool containsMachine = this.machines.Any(m => m.Name == selectedMachineName);
            if (!containsMachine)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackMachineON = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            IMachine deffendMachineON = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackMachineON==null )
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            if (deffendMachineON==null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            if (attackMachineON.HealthPoints<=0)
            {
                return $"Dead machine {attackMachineON.Name} cannot attack or be attacked";
            }
            if (deffendMachineON.HealthPoints<=0)
            {
                return $"Dead machine {deffendMachineON.Name} cannot attack or be attacked";
            }

            attackMachineON.Attack(deffendMachineON);
            return $"Machine {deffendMachineON.Name} was attacked by machine {attackMachineON.Name} - current health: {deffendMachineON.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = (IFighter)this.machines.FirstOrDefault(t => t.GetType().Name == "Fighter" && t.Name == fighterName);
            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            fighter.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (ITank)this.machines.FirstOrDefault(t => t.GetType().Name=="Tank" && t.Name == tankName);
            if (tank== null)
            {
                return $"Machine {tankName} could not be found";
            }
            tank.ToggleDefenseMode();
            return $"Tank {tankName} toggled defense mode";
        }
    }
}