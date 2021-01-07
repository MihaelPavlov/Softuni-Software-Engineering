using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly DwarfRepository dwarvesRepository;
        private readonly PresentRepository presentRepository;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.dwarvesRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            string message = string.Empty;
            IDwarf dwarf = null;
            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
                this.dwarvesRepository.Add(dwarf);
                message = $"Successfully added {dwarfType} named {dwarfName}.";
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
                this.dwarvesRepository.Add(dwarf);
                message = $"Successfully added {dwarfType} named {dwarfName}.";
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDwarfType));
            }
            return message;

        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarfToAddInstrument = this.dwarvesRepository.FindByName(dwarfName);
            if (dwarfToAddInstrument == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDwarf));
            }
            IInstrument instrument = new Instrument(power);
            dwarfToAddInstrument.AddInstrument(instrument);
            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            this.presentRepository.Add(present);
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            var dwarfs = this.dwarvesRepository.Models.OrderByDescending(d => d.Energy);
            var presentToCraft = this.presentRepository.Models.FirstOrDefault(p => p.Name == presentName);
            if (dwarfs.Count() == 0)
            {
                return $"There is no dwarf ready to start crafting!";
            }
            foreach (var dwarf in dwarfs)
            {
                if (dwarf.Energy >= 50)
                {
                    this.workshop.Craft(presentToCraft, dwarf);
                    if (dwarf.Energy == 0)
                    {
                        this.dwarvesRepository.Remove(dwarf);
                    }
                    if (presentToCraft.IsDone())
                    {
                        return $"Present {presentName} is done.";
                    }

                }
            }

            return $"Present {presentName} is not done.";


        }

        public string Report()
        {
            string message = string.Empty;


            message += ($"{this.presentRepository.Models.Count(p => p.IsDone())} presents are done!")+ Environment.NewLine;
                message+=("Dwarfs info:")+ Environment.NewLine;

            foreach (var dwarf in this.dwarvesRepository.Models)
            {
                message += ($"Name: {dwarf.Name}") + Environment.NewLine;
                    message+=($"Energy: {dwarf.Energy}") + Environment.NewLine;
                      message+=($"Instruments: {dwarf.Instruments.Count(i => !i.IsBroken())} not broken left") + Environment.NewLine;   
            }
            return message;
                
        }
    }
}
