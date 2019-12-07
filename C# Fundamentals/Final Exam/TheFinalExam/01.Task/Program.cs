using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace TheFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Complete")
            {
                string[] cmdArgs = command.Split(" ");
                string cmd = cmdArgs[0];

                if (cmd == "Make")
                {
                    if (cmdArgs[1] == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (cmdArgs[1] == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }

                }
                else if (cmd == "GetDomain")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string newEmail = "";
                    for (int i = email.Length-3; i < email.Length; i++)
                    {
                        newEmail += email[i];
                    }

                    Console.WriteLine(newEmail);
                    
                    
                        


                }
                else if (cmd == "GetUsername")
                {
                    if (!email.Contains("@"))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        int getIndex = email.IndexOf("@");

                        string newEmail = email.Substring(0, getIndex);
                        Console.WriteLine(newEmail);
                    }
                }
                else if (cmd == "Replace")
                {
                    string ch = cmdArgs[1];

                    email = email.Replace(ch, "-");
                    Console.WriteLine(email);
                }
                else if (cmd == "Encrypt")
                {
                    List<int> ascii = new List<int>();

                    for (int i = 0; i < email.Length; i++)
                    {
                        ascii.Add((char)email[i]);
                    }
                    Console.WriteLine(string.Join(" ", ascii));
                }
                command = Console.ReadLine();

            }


        }
    }
}
