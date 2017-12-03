namespace Task01
{
    using System;

    public static class Data
    {
        public static bool Repeat = true;

        public static void UnsortedArrayPrint(int[] num)
        {
            Console.WriteLine("Unsorted Array: ");
            Random rnd = new Random();
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = rnd.Next(0, 100);
                Console.WriteLine($"num[{i}]= {num[i]}");
            }
        }

        public static void SortedArrayPrint(int[] num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"num[{i}] = {num[i]} ");
            }
        }

        public static void BubleSort(int[] num)
        {
            Console.WriteLine("\nSorted Array: ");
            for (int k = num.Length - 1; k > 0; k--)
            {
                for (int i = 0; i < k; i++)
                {
                    if (num[i] > num[i + 1])
                    {
                        int buf = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = buf;
                    }
                }
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