using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
   public interface ICar
    {
        public string  Driver { get; set; }
        public string Model
        {
            get
            {
                return "488-Spider";
            }
        }


        public string UseBrakes()
        {
            return "Brakes!";
        }
        
        public string PushTheGasPedal()
        {
           return "Gas!";
        }

      

    }
}
