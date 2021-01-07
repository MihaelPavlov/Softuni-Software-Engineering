using System;
using System.Linq;
using System.IO;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("./text.txt");
            int counter = 0;

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    line = line.Replace('-', '@');
                    line = line.Replace(',', '@');
                    line = line.Replace('.', '@');
                    line = line.Replace('!', '@');
                    line = line.Replace('?', '@');

                    line = string.Join(" ", line.Split(' ').Reverse());
                    Console.WriteLine(line);
                }


                counter++;

            }
        }
    }
}
