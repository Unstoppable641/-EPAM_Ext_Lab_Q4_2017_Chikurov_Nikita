namespace Task04
{
    using System;

    public static class Data
    {
        public static bool Repeat = true;

        public static void WhileExit()
        {
            Console.WriteLine("\nTRY AGAIN ? [Y/N]");
            var ki = Console.ReadKey(true);
            if (ki.Key != ConsoleKey.Y)
            {
                Repeat = false;
                Console.ReadKey();
            }
        }

        public static void SortedArrayPrint(int[,] m, int a, int b)
        {
            int sum = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += m[i, j];
                    }
                }
            }

            Console.WriteLine($"\nbsum of elements of a two-dimensional array= {sum}");
        }

        public static void UnsortedArrayPrint(int[,] m, int a, int b)
        {
            Console.WriteLine("\nUNSORTED ARRAY: ");
            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    m[i, j] = rnd.Next(-10, 10);
                    Console.WriteLine($"m[{i}]= {m[i, j]}");
                }
            }
        }
    }
}
