namespace Task02
{
    using System;

   public class Data
   {
        public static void ThrowEx(int n)
        {
            if (n <= 0)
            {
                throw new System.ArgumentException("[n] must be greater than zero.\n");
            }
        }

        public static void PrintStairs(int n)
       {
            Console.Write("\n");
            for (int i = 1; i <= n; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n");
            }
        }
    }
}
