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
namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int length = 1000;
            const int maxRandom = 1000;
            const int size = 1000;

            long[] arrayTime = new long[size];
            int[] array = new int[length];

            var random = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxRandom);
            }

            Stopwatch stopWatch = new Stopwatch();

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                Sort.SumMax(array);
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort(arrayTime);
            Console.WriteLine($"search directly: {arrayTime[size / 2]}");

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                Sort.SumMax(array, Sort.IsPositive);
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort(arrayTime);
            Console.WriteLine($"through the delegate: {arrayTime[size / 2]}");

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                Sort.SumMax(array, delegate(int obj)
                {
                    if (obj > 0)
                    {
                        return true;
                    }

                    return false;
                });

                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort(arrayTime);
            Console.WriteLine($"through the delegate to the form of an anonymous method: {arrayTime[size / 2]}");

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                int[] positiveNumbers = Sort.SumMax(array, x => x > 0);
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort(arrayTime);
            Console.WriteLine($"through the delegate to the form of lambda expression: {arrayTime[size / 2]}");

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                var list = from x in array
                           where x > 0
                           select x;
                list.ToArray();
                stopWatch.Stop();
                arrayTime[i] = stopWatch.ElapsedTicks;
                stopWatch.Reset();
            }

            Array.Sort(arrayTime);
            Console.WriteLine($"LINQ Expressions: {arrayTime[size / 2]}");

            Console.ReadLine();
        }
    }
}
