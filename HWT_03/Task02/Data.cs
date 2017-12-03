namespace Task02
{
    using System;

    public static class Data
    {
        public static bool Repeat = true;
        public static void UnsortedArray(int[,,] m, int a, int b, int c)
        {
            Console.WriteLine("\nUNSORTED ARRAY: ");
            Random rnd = new Random();
            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    for (int z = 0; z < c; z++)
                    {
                        m[x, y, z] = rnd.Next(-5, 4);
                        Console.Write($"{m[x, y, z]}\t ");
                    }

                    Console.WriteLine(string.Empty);
                }

                Console.WriteLine(string.Empty);
            }
        }

        public static void SortedArray(int[,,] m, int a, int b, int c)
        {
            Console.WriteLine("\nSORTED ARRAY: ");
            for (int x = 0; x < a; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    for (int z = 0; z < c; z++)
                    {
                        if (m[x, y, z] > 0)
                        {
                            m[x, y, z] = 0;
                        }

                        Console.Write($"{m[x, y, z]}\t ");
                    }

                    Console.WriteLine(string.Empty);
                }

                Console.WriteLine(string.Empty);
            }
        }

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
    }
}
