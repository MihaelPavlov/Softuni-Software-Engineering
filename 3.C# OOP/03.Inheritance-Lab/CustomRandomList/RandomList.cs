using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
   public class RandomList :List<string>
    {
        Random random = new Random();
         public string GetRandomElement()
        {
            var elementIndex = random.Next(0,this.Count);
            return this[elementIndex];
        }
        
        public string RemoveRandomString()
        {
            var elementIndex = random.Next(0, this.Count);
            var elemtn = this[elementIndex];
            this.RemoveAt(elementIndex);
            return elemtn;



        }
    }
}
