namespace Task03
{
    using System;
    using System.Collections.Generic;

    public static class Sort
    {
        public static void SumMax(int[] array)
        {
            var list = new List<int>();
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    list.Add(array[i]);
                }
            }
        }

        public static int[] SumMax(int[] array, Predicate<int> condition)
        {
            var list = new List<int>();
            foreach (var item in array)
            {
                if (condition(item))
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
        }

        public static bool IsPositive(int obj)
        {
            return obj > 0;
        }
    }
}
