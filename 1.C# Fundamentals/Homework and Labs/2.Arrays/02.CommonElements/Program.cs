using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(separator: " ");
            string[] arr2 = Console.ReadLine().Split(separator: " ");

            foreach ( string element2 in arr2)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    
                    string element1 = arr1[i];

                    if (element2==element1)
                    {
                        Console.Write(element1+" ");
                        break;
                    }
                }
            }

        }
    }
}
