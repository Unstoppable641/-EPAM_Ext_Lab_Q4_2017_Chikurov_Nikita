/* 
 Задание 4
Элемент двумерного массива считается стоящим на чётной позиции,
если сумма номеров его позиций по обеим размерностям является
чётным числом (например, [1,1] – чётная позиция, а [1,2] - нет).
Определить сумму элементов массива, стоящих на чётных позициях.
 */
namespace Task04
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            while (Data.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter array [a] sizes to count the sum of even array members ");
                    var a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter array [b] sizes to count the sum of even array members ");
                    var b = int.Parse(Console.ReadLine());
                    if (a <= 0 || b <= 0)
                    {
                        throw new ArgumentException("[a, b] must be greater than zero.");
                    }
                    int[,] m = new int[a, b]; ////a, b - размеры массива

                    Data.UnsortedArrayPrint(m, a, b);
                    Data.SortedArrayPrint(m, a, b);
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
