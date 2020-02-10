using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Turple
{
   public class Threeuple<Titem1,Kitem2,Gitem3>
    {

        public Threeuple(Titem1 item1, Kitem2 item2,Gitem3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public Titem1 Item1 { get; set; }
        public Kitem2 Item2 { get; set; }
        public Gitem3 Item3 { get; set; }


        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
