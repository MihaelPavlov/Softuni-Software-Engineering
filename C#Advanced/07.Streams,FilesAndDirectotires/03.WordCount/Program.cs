using System;
using System.IO;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writter = new StreamWriter("Output.txt"))
            {
                using (var reader = new StreamReader("../../../words.txt"))
                {

                    var line = reader.ReadLine();

                    using (var input = new StreamReader("../../../text.txt"))
                    {

                        string[] cmd = line.Split(" ");
                        while (!input.EndOfStream)
                        {
                            var readLine = input.ReadLine().ToLower();
                            for (int i = 0; i < cmd.Length; i++)
                            {
                                if (readLine.Contains(cmd[i]))
                                {                                 
                                    writter.WriteLine(cmd[i]);
                                }

                            }
                        }


                    }
                }

                
            }
            
        }
    }
}
