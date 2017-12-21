namespace Task01
{
    using System;
    using System.Collections.Generic;

    public class DeletingEverySecondN
    {
        public const int WhileListHaveNumbers = 1;

        public static bool Delete = false;

        public static void PrintList(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static int ReadNumber()
        {
            for (;;)
            {
                int result;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}
