namespace task03
{
    using System;

    public class Data
    {
        public static void PrintPyramid(int n)
        {
            Console.Write("\n");
            for (int i = 1; i <= n; i++, n--)
            {
                for (var j = n - 1; j > 0; j--)
                {
                    Console.Write(" ");
                }

                for (var j = 0; j < i + i - 1; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n");
            }
        }
    }
}
