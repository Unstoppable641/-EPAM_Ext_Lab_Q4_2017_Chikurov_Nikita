/* 
 Задание 2
Написать программу, которая заменяет все положительные элементы
в трёхмерном массиве на нули. Число элементов в массиве и их тип
определяются разработчиком.

 */
namespace Task02
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
                    Console.WriteLine("Enter dimension [a] of a three-dimensional array: ");
                    var a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter dimension [b] of a three-dimensional array: ");
                    var b = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter dimension [c] of a three-dimensional array: ");
                    var c = int.Parse(Console.ReadLine());
                    if (a <= 0 || b <= 0 || c <= 0)
                    {
                        throw new ArgumentException("[a, b, c] must be greater than zero.");
                    }

                    int[,,] m = new int[a, b, c];

                    Data.UnsortedArray(m, a, b, c);
                    Data.SortedArray(m, a, b, c);
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
