using System;
using System.Collections.Generic;
using System.Text;
using _12.SOLID_Excersice.Models.Contrcats;
using _12.SOLID_Excersice.Models.Enumarations;

namespace _12.SOLID_Excersice.Models.Appenders
{
   public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
           
        }
        public override void Append(string dateTime , ReportLevel reportLevel, string message)
        {
            if (reportLevel>=this.ReportLevel)
            {
                this.Counter++;
            Console.WriteLine(this.Layout.Format,dateTime,reportLevel,message);

            }
        }
    }
}
