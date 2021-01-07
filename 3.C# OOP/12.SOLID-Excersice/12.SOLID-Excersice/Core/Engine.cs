using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using _12.SOLID_Excersice.Models.Enumarations;
using _12.SOLID_Excersice.Factories;
using _12.SOLID_Excersice.Models.Contrcats;
using _12.SOLID_Excersice.Models.Loggers;

namespace _12.SOLID_Excersice.Core
{
   public class Engine
    {

        public void Run()
        {
            List<IAppender> appenders = new List<IAppender>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = inputInfo[0];
                string layoutType = inputInfo[1];
                ReportLevel reportLevel= ReportLevel.Info;
                if (inputInfo.Length>2)
                {
                 reportLevel = Enum.Parse<ReportLevel>(inputInfo[2], true);

                }

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);
            }

            string input = Console.ReadLine();
            ILogger logger = new Logger(appenders.ToArray()) ;
            while (input!="END")
            {
                string[] inputInfo = input.Split('|');
                string loggerMethodType = inputInfo[0];
                string date = inputInfo[1];
                string message = inputInfo[2];

                if (loggerMethodType == "INFO")
                {
                    logger.Info(date, message);
                }
                else if (loggerMethodType== "WARNING")
                {
                    logger.Warning(date, message);
                }
                else if (loggerMethodType == "ERROR")
                {
                    logger.Error(date, message);
                }
                else if (loggerMethodType == "CRITICAL")
                {
                    logger.Critical(date, message);
                }
                else if (loggerMethodType == "FATAL")
                {
                    logger.Fatal(date, message);
                }
                input = Console.ReadLine();

            }
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
