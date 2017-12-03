namespace task04
{
    using System;

    public class Data
    {
        public static void PrintTree(int n)
        {
            Console.Write("\n");
            for (var a = 1; a <= n; a++)
            {
                for (int i = 1, k = n; i <= a; i++, k--)
                {
                    for (var j = k - 1; j > 0; j--)
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
}
