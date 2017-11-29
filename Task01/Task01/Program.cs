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
            var point = new Data.Point();
            bool repeat = true;
            while (repeat)
            {
                try
                {
                    Console.WriteLine("Enter X:");
                    point.X = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Y:");
                    point.Y = double.Parse(Console.ReadLine());
                    var circle = Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1;
                    var circleWithAHole = Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 0.5;
                    var square = point.X <= 1 && point.X >= -1 && point.Y <= 1 && point.Y >= -1;
                    var rhombus = Math.Abs(point.X) + Math.Abs(point.Y) <= 1;
                    var stretchedrhombus = (2 * Math.Abs(point.X)) + Math.Abs(point.Y) <= 1;
                    var iside = (point.X >= 0) && (point.Y >= 0);
                    var iIside = (point.X <= 0) && (point.Y >= 0);
                    var iIIside = (point.X <= 0) && (point.Y <= 0);
                    var iVside = (point.X >= 0) && (point.Y <= 0);
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
                            if (circle)
                            {
                                Data.SetMessage(Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1, "a", point.X, point.Y);
                            }
                            else
                            {
                                Data.SetMessage(false, "s", point.X, point.Y);
                            }

                            break;

                        ////Circle with a hole
                        case "b":
                            Console.WriteLine("\nYou selected a schedule [b]");
                            if (circle)
                            {
                                if (circleWithAHole)
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
                            if (square)
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
                            if (rhombus)
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
                            if (stretchedrhombus)
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
                            if (iside)
                            {
                                if (circle)
                                {
                                    Data.SetMessage(true, "f", point.X, point.Y);
                                }
                                else
                                {
                                    Data.SetMessage(false, "s", point.X, point.Y);
                                }
                            }
                            else if (iVside)
                            {
                                if (circle)
                                {
                                    Data.SetMessage(true, "f", point.X, point.Y);
                                }
                                else
                                {
                                    Data.SetMessage(false, "s", point.X, point.Y);
                                }
                            }
                            else if (iIside)
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
                            else if (iIIside)
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
                            if (iIside || iIIside)
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
                            else if (iVside || (point.X <= 0) && (point.Y <= 0))
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
                            else if ((point.X >= 0) && (point.Y <= 0) || iside)
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
                            if (iVside || iIIside)
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
                            else if (iIside || (point.X <= 0) && (point.Y <= 0))
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
                            else if (iside)
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
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR:{ex.Message} [TRY AGAIN ? Y/N]");
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
