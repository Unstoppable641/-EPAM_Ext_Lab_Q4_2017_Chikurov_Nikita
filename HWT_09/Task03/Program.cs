/*
 Задание 3
Написать методы поиска элемента в массиве (например, поиск всех
положительных элементов в массиве) в виде:
1. Метода, реализующего поиск напрямую;
2. Метода, которому условие поиска передаётся через делегат;
3. Метода, которому условие поиска передаётся через делегат в
виде анонимного метода;
4. Метода, которому условие поиска передаётся через делегат в
виде лямбда-выражения;
5. LINQ-выражения
Сравнить скорость выполнения вычислений.
 */

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Length = 100;
            const int MaxRandom = 100;
            const int Size = 100;

            long[] arrayTime = new long[Size];
            int[] array = new int[Length];

            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(MaxRandom);
            }

            Stopwatch stopWatch = new Stopwatch();



            // ИНИЦИАЛИЗИРОВАТЬ МЕТОДЫ
            // НЕ УСПЕЛ, ВЫШЛЮ ДОПИСАННЫЙ КОД ЧЕРЕЗ ДЕНЬ 9 Января.

            Console.ReadLine();
        }
    }
}
