using System;
using System.Collections.Generic;
using System.Text;

namespace _12.SOLID_Excersice.Models.Contrcats
{
  public  interface ILogger
    {
      IAppender[] Appenders { get; }
        void Error(string dateTime ,string message);
        void Info(string dateTime ,string message);

        void Fatal(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Warning(string dateTime, string message);
    }
}
