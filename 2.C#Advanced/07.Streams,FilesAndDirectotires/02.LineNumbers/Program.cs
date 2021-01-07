using System;
using System.IO;


namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                using (var writter = new StreamWriter("output.txt"))
                {
                    int counter = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writter.WriteLine($"{counter}. {line}");
                        counter++;
                    }
                }
                

            }

        }
    }
}
