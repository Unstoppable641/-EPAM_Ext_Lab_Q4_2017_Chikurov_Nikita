/*
 Задание 1
Напишите расширяющий метод, который определяет сумму элементов
массива. */
namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (EndProgram.Repeat)
            {
                try
                {
                    const int Random = 100;
                    Console.WriteLine("Enter dimension of array: ");
                    var length = int.Parse(Console.ReadLine());

                    int[] array = new int[length];
                    var rand = new Random();

                    for (var i = 0; i < array.Length; i++)
                    {
                        array[i] = rand.Next(Random);
                    }

                    Console.WriteLine($"Sum of array elements = {array.Sum()}");

                    EndProgram.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
