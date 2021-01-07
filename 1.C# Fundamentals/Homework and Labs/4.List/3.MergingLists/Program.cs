using System;
using System.Collections.Generic;
using System.Linq;


namespace _3.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstLineNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondLineNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();


            List<int> resultList = new List<int>();
            //smaller list
            int countSmaller = Math.Min(firstLineNumbers.Count, secondLineNumbers.Count);
            for (int i = 0; i < countSmaller; i++)
            {

                resultList.Add(firstLineNumbers[i]);
                resultList.Add(secondLineNumbers[i]);

                
                
            }
            //bigger list
            int count2 = Math.Max(firstLineNumbers.Count, secondLineNumbers.Count);

            //who is the bigger list
            if (!(firstLineNumbers.Count==secondLineNumbers.Count))
            {
                List<int> biggerList;
                //if smallList queal to firstLineNumber ,The second list is bigger .
                if (countSmaller == firstLineNumbers.Count)
                {
                    biggerList = secondLineNumbers;
                }
                else
                {
                    biggerList = firstLineNumbers;
                }
                for (int i = countSmaller; i < count2; i++)
                {
                    resultList.Add(biggerList[i]);
            }

            }

            
            Console.WriteLine(string.Join(" ",resultList));
        }
    }
}
