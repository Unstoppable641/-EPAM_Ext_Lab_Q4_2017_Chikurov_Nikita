using System.Collections.Generic;

namespace Task03
{
    using System;

    public static class Sort
    {
        public static int[] SumMax(int[] array)
        {
            var list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
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
