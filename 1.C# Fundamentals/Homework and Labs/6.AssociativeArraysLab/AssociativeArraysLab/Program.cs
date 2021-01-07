using System;

namespace AssociativeArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //dobro chetivo c# ?



            //int[] words = {1,2,3,4,5};

            //var result = words.Where(w => words.Length%2);
            //console.writeline(string.join(" ", result));

            string[] words = { "abc", "def" };

            var result = words.select(w => w + "x");
            console.writeline(string.join(" ", result));

            List<int> nums = new List<int> { 1, 4, 57, 1, 2, 5453, 532, 21 };
            nums.OrderBy(n => n);
            Console.WriteLine(string.Join(" ", nums));


            // ternary conditional operator ? :
        }
    }
}
