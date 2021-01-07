using System;

namespace GenericScale
{
   public class StartUp
    {
        static void Main(string[] args)
        {
           var scale = new EqualityScale<int>(7,9);
           

            Console.WriteLine(scale.IsFirstGreater());
        }
    }
}
