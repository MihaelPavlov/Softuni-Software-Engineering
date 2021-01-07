using System;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ");
            int n = int.Parse(Console.ReadLine());

            

            for (int i = 0; i < n; i++)
            {
                string firstNum = arr[0];
                for (int index = 1; index < arr.Length; index++)
                {
                    string currentElement = arr[index];
                    arr[index - 1] = currentElement;

                }
                arr[arr.Length - 1] = firstNum;
            }
            
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
