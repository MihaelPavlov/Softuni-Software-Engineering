using System;
using System.Collections.Generic;
using System.Text;
using _12.SOLID_Excersice.Models.Enumarations;
using _12.SOLID_Excersice.Models.Files;

namespace _12.SOLID_Excersice.Models.Appenders
{
  public  class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.LogFile = logFile;
        }
        public ILogFile LogFile { get; }
    
        public override void Append(string dateTime, ReportLevel logLevel, string message)
        {
            this.Counter++;
            this.LogFile.Write(string.Format(this.Layout.Format, dateTime, logLevel, message));           

            
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.LogFile.Size}";
        }
    }
}
