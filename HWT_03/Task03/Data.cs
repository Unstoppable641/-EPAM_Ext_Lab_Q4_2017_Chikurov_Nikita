namespace Task03
{
    using System;

    public static class Data
    {
        public static bool Repeat = true;

        public static void UnsortedArrayPrint(int[] m)
        {
            Console.WriteLine("\nUNSORTED ARRAY: ");
            Random rnd = new Random();
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(-10, 10);//todo pn хардкод
				Console.WriteLine($"m[{i}]= {m[i]}");
            }
        }

        public static void SumPrint(int[] m)
        {
            int sum = 0;
            Console.WriteLine("\nARRAY WITH A SUM OF POSITIVE NUMBERS: ");
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] >= 0)
                {
                    sum += m[i];
                }

                Console.WriteLine($"m[{i}]= {m[i]}");
            }

            Console.Write($"\nSum = {sum}\n");
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
