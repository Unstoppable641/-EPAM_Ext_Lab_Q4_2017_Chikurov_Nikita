namespace Task02
{
    using System;

    public class Data
    {
        public static void FindD(double h, double a, double b, double f)
        {
            double d;
            d = (b * b) - ((4 * a) * f);

            if (d == 0)
            {
                double x1 = -b / (2 * a);
                Console.WriteLine($"Дискриминант = 0, \nx = {x1}");
            }
            else if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(Convert.ToDouble(d))) / (2 * a);
                double x2 = (-b - Math.Sqrt(Convert.ToDouble(d))) / (2 * a);
                Console.WriteLine($"Дискриминант = {d},\nx1 = {x1},\nx2 = {x2}");
            }
            else
            {
                Console.WriteLine("Дискриминант отрицательный, корней нет\n");
            }
        }

        public static void FindC(double h, double a, double b)
        {
            double f = (a * (h * h)) * ((Math.Sin(b * h) + (b * ((h * h) * h))) * (Math.Cos(a * h)));
            Console.WriteLine($"Коэф c = {f}");
            FindD(h, a, b, f);
        }

        public static void FindB(double h, double a)
        {
            double b1 = 3 + Math.Abs(Math.Tan(a * (h * h)) - Math.Sin(a * h));
            double b = 1 - Math.Sqrt(3 / b1);
            Console.WriteLine($"Коэф b = {b}");
            FindC(h, a, b);
        }

        public static void FindA(double h)
        {
            double a1 = 1 - ((Math.Sin(4 * h) * Math.Cos((h * h))) + 18);
            double a2 = Math.Abs(Math.Sin(8 * h)) + 17;
            double a = Math.Sqrt(a2 / (a1 * a1));
            Console.WriteLine($"Коэф a = {a}");
            FindB(h, a);
        }
    }
}
