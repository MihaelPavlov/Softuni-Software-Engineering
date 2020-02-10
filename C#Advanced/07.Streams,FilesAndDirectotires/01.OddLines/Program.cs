using System;
using System.Text;
using System.IO;


namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {

               int counter = 1;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        
                        Console.WriteLine(line);
                    }
                    counter++;
                }

                
            }
            
        }
    }
}
