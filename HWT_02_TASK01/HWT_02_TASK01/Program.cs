/*
 Задание 1
Написать программу, которая определяет площадь прямоугольника со
сторонами a и b.Если пользователь вводит некорректные значения
(отрицательные, или 0), должно выдаваться сообщение об ошибке.
Возможность ввода пользователем строки вида «абвгд», или нецелых
чисел игнорировать.
*/
namespace HWT_02_TASK01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var findTheArea = true;
            while (findTheArea)
            {
                try
                {
                    Console.WriteLine("Enter the LENGTH [a] of the rectangle: ");
                    int a = int.Parse(Console.ReadLine());
                    Data.ThrowExA(a);

                    Console.WriteLine("Enter the WIDTH [B] of the rectangle: ");
                    int b = int.Parse(Console.ReadLine());
                    Data.ThrowExB(b);

                    Data.GetArea(a, b);

                    Console.WriteLine("try again? (Y/N)");
                    var ki = Console.ReadKey(true);
                    if (ki.Key != ConsoleKey.Y)
                    {
                        findTheArea = false;
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}