/* 
Задание 2

Программа должна выводить пользователю промежуточные
вычисления(например, a, b, c и дискриминант (если вычисляли
при помощи него) и корни(если есть)).

*/

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            bool repeat = true;
            var f = new Data();
            while (repeat)
            {
                try
                {
                    Console.WriteLine("Введите коэффициент [h]:");
                    double h = double.Parse(Console.ReadLine());
                    Data.FindA(h);
                    repeat = false;
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message} [TRY AGAIN ? Y/N]");
                    var ki = Console.ReadKey(true);
                    if (ki.Key != ConsoleKey.Y)
                    {
                        repeat = false;
                    }
                }
            }
        } 
    }
}
