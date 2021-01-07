using System;
using System.Linq;

namespace _13.Workshop_CustomDoublyLinkedList
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList myList = new DoublyLinkedList();

            for (int i = 1; i <= 10; i++)
            {
                myList.AddFirst(i);
                
            }
            for (int i = 1; i <= 10; i++)
            {
                myList.AddLast(i);
            }
          

            myList.ForEach(x => Console.WriteLine($"{x}"));

            int[] arr = myList.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
