/* 
 Задание 3
Написать программу, которая определяет сумму неотрицательных
элементов в одномерном массиве. Число элементов в массиве и их тип
определяются разработчиком.
 */
namespace Task03
{
    using System;

   public static class Program
    {
        static void Main(string[] args)
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
                    int[] m = new int[size];

                    Data.UnsortedArrayPrint(m);
                    Data.SumPrint(m);
                    Data.WhileExit();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"\n\nERROR: {ex.Message}");
                }
            }
        }
    }
}
