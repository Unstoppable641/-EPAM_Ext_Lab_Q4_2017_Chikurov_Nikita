/*
Задание 1

Написать консольное приложение, которое проверяет
принадлежность точки заштрихованной области.
Пользователь вводит координаты точки (x; y) и выбирает
букву графика(a-к). В консоли должно высветиться сообщение:
«Точка[(x; y)] принадлежит фигуре[г]».

*/

namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var point = GetPoint();

            Console.WriteLine("Select schedule:" +
                              " \na -- Circle," +
                              " \nb -- Circle with a hole," +
                              " \nc -- Square," +
                              " \nd -- Rhombus," +
                              " \ne -- Stretched rhombus," +
                              " \nf -- Semicircle + triangle," +
                              " \ng -- Triangle," +
                              " \nh -- Inverted flag," +
                              " \ni -- Pentagon," +
                              " \nj -- V-shaped figure with an infinite area");
            string choice = Console.ReadLine();
            switch (choice)
            {
                ////Circle
                case "a":
                    Console.WriteLine("\nYou selected a schedule [a]");
                    if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                    {
                        SetMessage(true, "a");
                    }
                    else
                    {
                        SetMessage(false, "s");
                    }

                    break;

                ////Circle with a hole
                case "b":
                    Console.WriteLine("\nYou selected a schedule [b]");
                    if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) >= 0.5)
                        {
                            SetMessage(true, "b");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else SetMessage(false, "s");
                    break;

                ////kvadrat
                case "c":
                    Console.WriteLine("\nYou selected a schedule [c]");
                    if (point.X <= 1 && point.X >= -1 && point.Y <= 1 && point.Y >= -1)
                    {
                        SetMessage(true, "c");
                    }
                    else
                    {
                        SetMessage(false, "s");
                    }

                    break;

                ////romb
                case "d":
                    Console.WriteLine("\nYou selected a schedule [d]");
                    if (Math.Abs(point.X) + Math.Abs(point.Y) <= 1)
                    {
                        SetMessage(true, "d");
                    }
                    else
                    {
                        SetMessage(false, "s");
                    }

                    break;

                ////vityanutii romb
                case "e":
                    Console.WriteLine("\nYou selected a schedule [e]");
                    if ((2 * Math.Abs(point.X)) + Math.Abs(point.Y) <= 1)
                    {
                        SetMessage(true, "e");
                    }
                    else
                    {
                        SetMessage(false, "s");
                    }

                    break;

                ////polkryga + triangl.
                case "f":
                    Console.WriteLine("\nYou selected a schedule [f]");
                    if (point.X >= 0 && point.Y >= 0)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                        {
                            SetMessage(true, "f");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X >= 0 && point.Y <= 0)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                        {
                            SetMessage(true, "f");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y <= 0.5 * point.X + 1)
                        {
                            SetMessage(true, "f");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X <= 0 && point.Y <= 0)
                    {
                        if (point.Y >= -0.5 * point.X - 1)
                        {
                            SetMessage(true, "f");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }

                    break;

                ////triangle
                case "g":
                    Console.WriteLine("\nYou selected a schedule [g]");
                    if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.Y <= (3 * point.X) + 2)
                        {
                            SetMessage(true, "g");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.Y >= -1)
                        {
                            SetMessage(true, "g");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))
                    {
                        if (point.Y <= -3 * point.X + 2)
                        {
                            SetMessage(true, "g");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }

                    break;

                ////reversive flag
                case "h":
                    Console.WriteLine("\nYou selected a schedule [h]");
                    if ((point.Y <= 0 && point.X >= 0) || (point.X <= 0 && point.Y <= 0))
                    {
                        if (point.Y >= -2)
                        {
                            SetMessage(true, "h");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.X >= -1)
                        {
                            SetMessage(true, "h");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X >= 0 && point.Y >= 0)
                    {
                        if (point.Y < point.X)
                        {
                            SetMessage(true, "h");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            SetMessage(true, "h");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))
                    {
                        if (point.X <= 1)
                        {
                            SetMessage(true, "h");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }

                    break;

                ////Fiveangle
                case "i":
                    Console.WriteLine("\nYou selected a schedule [i]");
                    if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.Y <= (2 * point.X) + 3)
                        {
                            SetMessage(true, "i");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if ((point.Y <= 0 && point.X <= 0) || (point.Y <= 0 && point.X >= 0))
                    {
                        if (point.Y >= 0.3333333333333333333 * point.X - 0.3333333333333333333)
                        {
                            SetMessage(true, "i");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.Y <= 0 && point.X >= 0)
                    {
                        if (point.Y <= 0)
                        {
                            SetMessage(true, "i");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            SetMessage(true, "i");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }

                    break;

                ////4 lines + infinity 
                case "j":
                    Console.WriteLine("\nYou selected a schedule [j]");
                    if ((point.Y >= 0 && point.X >= 0) || (point.Y >= 0 && point.X <= 0))
                    {
                        if (point.Y >= 1)
                        {
                            SetMessage(true, "j");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.Y >= 0 && point.X >= 0)
                    {
                        if (point.Y < point.X)
                        {
                            SetMessage(true, "j");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }
                    else if (point.Y >= 0 && point.X <= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            SetMessage(true, "j");
                        }
                        else
                        {
                            SetMessage(false, "s");
                        }
                    }

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGraphics under this letter does not exist.");
                    break;
            }

            Console.ReadKey();
        }

        private static Point GetPoint()
        {
            var point = new Point();
            Console.WriteLine("Enter X:");
            point.X = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y:");
            point.Y = double.Parse(Console.ReadLine());

            return point;
        }

        private static void SetMessage(bool f, string s)
        {
            var point = GetPoint();
            if (f)
            {
                Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure {s}");
            }
            else
            {
                Console.WriteLine("BAD POINT.");
            }
        }

        private class Point
        {
            public double X { get; set; }

            public double Y { get; set; }
        }
    }
}
