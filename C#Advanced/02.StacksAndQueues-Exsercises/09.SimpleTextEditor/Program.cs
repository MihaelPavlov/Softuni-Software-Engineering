using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> backUp = new Stack<string>();
            

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    backUp.Push(text.ToString());
                    string stringtoAdd = cmdArgs[1];

                    text.Append(stringtoAdd);


                }
                else if (cmd == "2")
                {
                    backUp.Push(text.ToString());
                    int numberToErase = int.Parse(cmdArgs[1]);
                    text = text.Remove(text.Length-numberToErase, numberToErase);
                }
                else if (cmd == "3")
                {
                    int number = int.Parse(cmdArgs[1]) - 1;

                    Console.WriteLine(text[number]);


                }
                else if (cmd == "4")
                {
                    text.Clear();
                    text.Append(backUp.Pop());
                }
   
            }
        }
    }
}
