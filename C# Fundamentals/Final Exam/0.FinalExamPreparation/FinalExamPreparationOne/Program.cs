using System;
using System.Text;
using System.Linq;

namespace FinalExamPreparationOne
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string command = Console.ReadLine();

            
            while (command !="Done")
            {
                string[] cmdArgs = command.Split(" ");
                string cmd = cmdArgs[0];

                if (cmd == "Change")
                {
                    string ch = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    input=input.Replace(ch, replacement);
                    Console.WriteLine(input);
                }
                else if (cmd == "Includes")
                {
                    string str = cmdArgs[1];

                    bool includes = input.Contains(str);
                    Console.WriteLine(includes);
                }
                else if (cmd == "End")
                {
                    string str = cmdArgs[1];
                    bool end = input.EndsWith(str);
                    Console.WriteLine(end);
                }
                else if (cmd =="Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (cmd =="FindIndex")
                {
                    string ch = cmdArgs[1];

                    int findIndex = input.IndexOf(ch);//Carful
                    Console.WriteLine(findIndex);
                }
                else if (cmd=="Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]); 
                    
                    input = input.Remove(0, startIndex);


                    int lenght = int.Parse(cmdArgs[2]);
                    int lastIndex = (input.Length - 1);
                    input = input.Remove(startIndex,lastIndex-lenght+1 );
                    
                    Console.WriteLine(input);
                }





                command = Console.ReadLine();
            }
               
            
        }
    }
}
