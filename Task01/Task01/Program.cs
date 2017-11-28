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

    public static class Program 
    {
        public static void Main(string[] args)
        {
            var point = Data.GetPoint();

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
                        Data.SetMessage(true, "a", point.X, point.Y);
                    }
                    else
                    {
                        Data.SetMessage(false, "s", point.X, point.Y);
                    }

                    break;

                ////Circle with a hole
                case "b":
                    Console.WriteLine("\nYou selected a schedule [b]");
                    if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) >= 0.5)
                        {
                            Data.SetMessage(true, "b", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else Data.SetMessage(false, "s", point.X, point.Y);
                    break;

                ////kvadrat
                case "c":
                    Console.WriteLine("\nYou selected a schedule [c]");
                    if (point.X <= 1 && point.X >= -1 && point.Y <= 1 && point.Y >= -1)
                    {
                        Data.SetMessage(true, "c", point.X, point.Y);
                    }
                    else
                    {
                        Data.SetMessage(false, "s", point.X, point.Y);
                    }

                    break;

                ////romb
                case "d":
                    Console.WriteLine("\nYou selected a schedule [d]");
                    if (Math.Abs(point.X) + Math.Abs(point.Y) <= 1)
                    {
                        Data.SetMessage(true, "d", point.X, point.Y);
                    }
                    else
                    {
                        Data.SetMessage(false, "s", point.X, point.Y);
                    }

                    break;

                ////vityanutii romb
                case "e":
                    Console.WriteLine("\nYou selected a schedule [e]");
                    if ((2 * Math.Abs(point.X)) + Math.Abs(point.Y) <= 1)
                    {
                        Data.SetMessage(true, "e", point.X, point.Y);
                    }
                    else
                    {
                        Data.SetMessage(false, "s", point.X, point.Y);
                    }

                    break;

                ////polkryga + triangl.
                case "f":
                    Console.WriteLine("\nYou selected a schedule [f]");
                    if (point.X >= 0 && point.Y >= 0)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                        {
                            Data.SetMessage(true, "f", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X >= 0 && point.Y <= 0)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                        {
                            Data.SetMessage(true, "f", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y <= 0.5 * point.X + 1)
                        {
                            Data.SetMessage(true, "f", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X <= 0 && point.Y <= 0)
                    {
                        if (point.Y >= -0.5 * point.X - 1)
                        {
                            Data.SetMessage(true, "f", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
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
                            Data.SetMessage(true, "g", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.Y >= -1)
                        {
                            Data.SetMessage(true, "g", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))
                    {
                        if (point.Y <= -3 * point.X + 2)
                        {
                            Data.SetMessage(true, "g", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
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
                            Data.SetMessage(true, "h", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if (point.X >= -1)
                        {
                            Data.SetMessage(true, "h", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X >= 0 && point.Y >= 0)
                    {
                        if (point.Y < point.X)
                        {
                            Data.SetMessage(true, "h", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            Data.SetMessage(true, "h", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))
                    {
                        if (point.X <= 1)
                        {
                            Data.SetMessage(true, "h", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
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
                            Data.SetMessage(true, "i", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if ((point.Y <= 0 && point.X <= 0) || (point.Y <= 0 && point.X >= 0))
                    {
                        if (point.Y >= 0.3333333333333333333 * point.X - 0.3333333333333333333)
                        {
                            Data.SetMessage(true, "i", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.Y <= 0 && point.X >= 0)
                    {
                        if (point.Y <= 0)
                        {
                            Data.SetMessage(true, "i", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            Data.SetMessage(true, "i", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
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
                            Data.SetMessage(true, "j", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.Y >= 0 && point.X >= 0)
                    {
                        if (point.Y < point.X)
                        {
                            Data.SetMessage(true, "j", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
                        }
                    }
                    else if (point.Y >= 0 && point.X <= 0)
                    {
                        if (point.Y > -point.X)
                        {
                            Data.SetMessage(true, "j", point.X, point.Y);
                        }
                        else
                        {
                            Data.SetMessage(false, "s", point.X, point.Y);
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
    }
}
