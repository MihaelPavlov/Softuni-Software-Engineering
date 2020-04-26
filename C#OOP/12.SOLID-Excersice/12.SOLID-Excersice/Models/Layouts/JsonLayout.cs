using System;
using System.Collections.Generic;
using System.Text;

namespace _12.SOLID_Excersice.Models.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Format => @"{{
  ""log"": {{
    ""date"": {0},
    ""level"": {1},
    ""message"": {2}
  }}
}}";


    }
}
