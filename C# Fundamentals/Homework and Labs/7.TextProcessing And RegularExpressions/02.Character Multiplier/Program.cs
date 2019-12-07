using System;

namespace _02.Character_Multiplier
{
    class Program
    {


        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            string str = tokens[0];
            string str2 = tokens[1];
            
            
            Console.WriteLine(FindSum(str, str2));
        }

        private static int FindSum(string str, string str2)
        {
            string longerWord = string.Empty;
            string shorWord = string.Empty;
            int sum = 0;
            if (str.Length >= str2.Length)
            {
                longerWord = str;
                shorWord = str2;
            }
            else
            {
                longerWord = str2;
                shorWord = str;
            }

            for (int i = 0; i < shorWord.Length; i++)
            {
                sum += longerWord[i] * shorWord[i];
            }
            for (int i = shorWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }
            return sum;
        }
    }
}
