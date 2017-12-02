namespace HWT_02_TASK01
{
    using System;

   public class Data
    {
        public static void ThrowExA(int a)
        {
            if (a <= 0)
            {
                throw new System.ArgumentException("[a] should not be less than or equal to zero.\n");
            }
        }

        public static void ThrowExB(int b)
        {
            if (b <= 0)
            {
                throw new System.ArgumentException("[a] should not be less than or equal to zero.\n");
            }
        }

        public static void GetArea(int a, int b)
        {
            int area = a * b;
            Console.Write($"\nThe area of the rectangle is {area}\n");
            Console.WriteLine("\n");
        }
    }
}
