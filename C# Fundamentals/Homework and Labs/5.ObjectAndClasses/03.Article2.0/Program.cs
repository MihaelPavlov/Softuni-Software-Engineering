using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Article2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ");
            var random = new Random();//Read the method
            var shuffedWords = new List<string>(); // the list where we collect the shuffleWords

            foreach (var word in words) 
            {
                int neWIndex =  random.Next(0, shuffedWords.Count + 1);//The suffle
                shuffedWords.Insert(neWIndex , word);// where we put it
            }
            foreach (var word in shuffedWords)
            {
                Console.WriteLine(word);// print
            }

        } 

    }    
             
       
        
    
    class Birthday
    {
        public int Day  { get; set; }
        public int Mount { get; set; }
        public int Year { get; set; }

        public void AddYear()
        {

        }
    }
}
