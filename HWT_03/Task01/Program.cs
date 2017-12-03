/* 
 * Задание 1
Написать программу, которая генерирует случайным образом
элементы массива (число элементов в массиве и их тип определяются
разработчиком), определяет для него максимальное и минимальное
значения, сортирует массив и выводит полученный результат на экран.
Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.)
использовать в данном задании запрещается.
*/
namespace Task01
{
    using System;

   public static class Program
    {
        public static void Main(string[] args)
        {
            while (Data.Repeat)
            {
                try
                {
                    Console.WriteLine("enter the dimension of the array: ");
                    var size = int.Parse(Console.ReadLine());
                    if (size <= 0)
                    {
                        throw new ArgumentException("[size] must be greater than zero.");
                    }

                    int[] num = new int[size];
                    Data.UnsortedArrayPrint(num);
                    Data.BubleSort(num);
                    Data.SortedArrayPrint(num);
                    Data.WhileExit(); //// функция выхода из цикла.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\nERROR: {ex.Message}");
                }
            }
        }
    }
}
