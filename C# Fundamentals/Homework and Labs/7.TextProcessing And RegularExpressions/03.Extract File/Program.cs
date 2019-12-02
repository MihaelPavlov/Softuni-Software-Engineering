using System;

namespace _03.Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int startIndexFile =text.LastIndexOf("\\")+1;
            string fileName = text.Substring(startIndexFile);

            int endIndex = fileName.LastIndexOf('.')+1;
            string nameOfFile = fileName.Substring(0, endIndex - 1);
            string extensionFile = fileName.Substring(endIndex);

            
            

            
            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {extensionFile}");
        }
    }
}
