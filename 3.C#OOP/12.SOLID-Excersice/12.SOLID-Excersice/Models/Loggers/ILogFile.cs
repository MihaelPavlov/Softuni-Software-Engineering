using System;
using System.Collections.Generic;
using System.Text;

namespace _12.SOLID_Excersice.Models.Files
{
  public  interface ILogFile
    {
      
        int Size { get; }
        void Write(string message);
    }
}
