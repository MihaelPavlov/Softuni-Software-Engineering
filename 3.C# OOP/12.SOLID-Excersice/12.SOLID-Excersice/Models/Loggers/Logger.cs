using _12.SOLID_Excersice.Models.Contrcats;
using _12.SOLID_Excersice.Models.Enumarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12.SOLID_Excersice.Models.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appender;
      
        public Logger( params IAppender[] appender)
        {
            this.Appenders = appender;
      
        }
        public IAppender[] Appenders 
        {
            get
            {
                return this.appender;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders),"Value cannot be null");
                }
                this.appender = value;
            }
        }

        public void Critical(string dateTime, string message)
        {
            AppendMessage(dateTime, ReportLevel.Critical ,message);

        }
        public void Warning(string dateTime, string message)
        {
            AppendMessage(dateTime, ReportLevel.Warning, message);

        }

        public void Error(string dateTime, string message)
        {
            AppendMessage(dateTime,ReportLevel.Error ,message);
        }


        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(dateTime, ReportLevel.Fatal, message);

            }
        }

        public void Info(string dateTime, string message)
        {
            AppendMessage(dateTime, ReportLevel.Info, message);


        }
        private void AppendMessage(string dateTime,ReportLevel error, string message )
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(dateTime, error, message);

            }
        }

        
    }
}
