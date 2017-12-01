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
            var repeat = true;
            while (repeat)//todo pn можешь не исправлять, то выглядит, как будто лабораторку в универе сдаешь, а не программу для заказчика пишешь. Разделяй слои UI и бизнес-логики.
            {
                try
                {
                    Console.WriteLine("Enter the LENGTH [a] of the rectangle: ");
                    var a = int.Parse(Console.ReadLine());
                    if (a <= 0)
                    {
                        throw new System.ArgumentException("[a] should not be less than or equal to zero.\n");
                    }

                    Console.WriteLine("Enter the WIDTH [B] of the rectangle: ");
                    var b = int.Parse(Console.ReadLine());
                    if (b <= 0)
                    {
                        throw new System.ArgumentException("[b] should not be less than or equal to zero.\n");
                    }

                    Console.Write($"\nThe area of the rectangle is {a * b}\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("try again? (Y/N)");
                    var ki = Console.ReadKey(true);
                    if (ki.Key != ConsoleKey.Y)
                    {
                        repeat = false;
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