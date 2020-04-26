using _12.SOLID_Excersice.Models.Contrcats;
using _12.SOLID_Excersice.Models.Enumarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12.SOLID_Excersice
{
   public interface IAppender
    {
        ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        void Append(string dateTime, ReportLevel logLevel, string message);
   
    }
}
