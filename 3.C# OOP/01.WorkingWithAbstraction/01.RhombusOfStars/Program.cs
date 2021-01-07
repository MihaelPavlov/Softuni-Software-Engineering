using System;
using System.Collections.Generic;
using System.Text;

namespace _01.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                DrawLines(n, sb, i);
            }
            for (int i = n - 2; i >= 0; i--)
            {
                DrawLines(n, sb, i);

            }
            Console.WriteLine(sb);

        }

        private static void DrawLines(int n, StringBuilder sb, int i)
        {
            sb.Append(new string(' ', n - i - 1));
            for (int j = 0; j < i + 1; j++)
            {
                sb.Append("*");
                if (j != i)
                {
                    sb.Append(' ');
                }
            }

            sb.AppendLine();
        }
    }
}
