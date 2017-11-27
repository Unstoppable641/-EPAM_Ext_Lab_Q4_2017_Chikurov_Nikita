using System;

/* 
Задание 2

Программа должна выводить пользователю промежуточные
вычисления(например, a, b, c и дискриминант (если вычисляли
при помощи него) и корни(если есть)).

*/

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициент [h]:");
            double h = Double.Parse(Console.ReadLine());
            double d;

            double a1 = (1 - Math.Sin(4 * h) * Math.Cos((h * h) + 18));
            double a2 = Math.Abs(Math.Sin(8*h)) + 17;
            double a = Math.Sqrt(a2 / (a1 * a1));
            Console.WriteLine($"Коэф a = {a}");

            double b1 = 3 + Math.Abs(Math.Tan(a * (h * h)) - Math.Sin(a * h));
            double b = 1 - Math.Sqrt(3 / b1);
            Console.WriteLine($"Коэф b = {b}");

            double c = a * (h * h) * Math.Sin(b * h) + b * (h * h * h) * Math.Cos(a * h);
            Console.WriteLine($"Коэф c = {c}");

            d = b*b - 4*a*c;
            if (d < 0)
            {
                Console.WriteLine("Дискриминант отрицательный, корней нет\n");
            }
            if (d == 0)
            {
                double x1 = -b/(2*a);
                Console.WriteLine($"Дискриминант = 0, \nx = {x1}");
            }

            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(Convert.ToDouble(d)))/(2*a);
                double x2 = (-b - Math.Sqrt(Convert.ToDouble(d)))/(2*a);
                Console.WriteLine($"Дискриминант = {d},\nx1 = {x1},\nx2 = {x2}");
            }
        }
    }
}
