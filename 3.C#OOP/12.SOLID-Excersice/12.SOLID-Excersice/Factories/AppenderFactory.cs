using _12.SOLID_Excersice.Models.Appenders;
using System;
using System.Collections.Generic;
using System.Text;
using _12.SOLID_Excersice.Models.Files;
using _12.SOLID_Excersice.Models.Enumarations;

namespace _12.SOLID_Excersice.Factories
{
  public static class AppenderFactory
    {
       public static IAppender CreateAppender(string type, ILayout layout , ReportLevel reportLevel)
        {
            string appenderType = type.ToLower();

            switch (appenderType)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout) { ReportLevel= reportLevel};
                case "fileappender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }
        }
    }
}
