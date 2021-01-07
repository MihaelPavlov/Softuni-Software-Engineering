using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy>0 && dwarf.Instruments.Any())
            {
                IInstrument currInstrument = dwarf.Instruments.First();

                while (!present.IsDone() && dwarf.Energy>0 && !currInstrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    currInstrument.Use();
                }
                if (currInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currInstrument);
                }
                if (present.IsDone())
                {
                    break;
                }
            }
            //foreach (var instrument in dwarf.Instruments)
            //{
            //    if (dwarf.Energy <= 0)
            //    {
            //        return;
            //    }
            //    if (instrument.IsBroken())
            //    {
            //        continue;
            //    }

            //    while (!present.IsDone())
            //    {
            //        if (dwarf.Energy == 0)
            //        {
            //            return;
            //        }
            //        if (instrument.IsBroken())
            //        {
                        
            //            break;
            //        }
            //        present.GetCrafted();
            //        dwarf.Work();
            //        instrument.Use();
            //        if (present.IsDone())
            //        {
            //            return;
            //        }
            //    }

            //}


        }
    }
}
