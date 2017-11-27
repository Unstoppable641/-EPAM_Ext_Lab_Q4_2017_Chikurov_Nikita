using System;
using System.Diagnostics;

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
    class Program
    {
        private class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        private static Point GetPoint()
        {
            var point = new Point();

            Console.WriteLine("Enter X:");
            point.X = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y:");
            point.Y = Double.Parse(Console.ReadLine());
            return point;
        }

        static void Main(string[] args)
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
                              " \nh -- Inverted flag, \ni -- Pentagon," +
                              " \nj -- V-shaped figure with an infinite area");
            string choice = Console.ReadLine();
            switch (choice)
            {
                //Circle
                case "a": //+
                    Console.WriteLine("\nYou selected a schedule [a]");
                    if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                        Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'a'"); 
                    else Console.WriteLine("BAD POINT.");
                    break;

                //Circle with a hole
                case "b": //+
                    Console.WriteLine("\nYou selected a schedule [b]");
                    if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) >= 0.5)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'b'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else Console.WriteLine("BAD POINT.");
                    break;

                //kvadrat
                case "c": //+
                    Console.WriteLine("\nYou selected a schedule [c]");
                    if(point.X <= 1 && point.X >= -1 && point.Y <= 1 && point.Y >= -1 )
                        Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'c'");
                    else Console.WriteLine("BAD POINT.");
                    break;

                //romb
                case "d": //+
                    Console.WriteLine("\nYou selected a schedule [d]");
                    if (Math.Abs(point.X) + Math.Abs(point.Y) <= 1)
                        Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'd'");
                    else Console.WriteLine("BAD POINT.");
                    break;

                //vityanutii romb
                case "e": //+
                    Console.WriteLine("\nYou selected a schedule [e]");
                    if (2*(Math.Abs(point.X)) + Math.Abs(point.Y) <= 1)
                        Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'e'");
                    else Console.WriteLine("BAD POINT.");
                    break;

                //polkryga + triangl.
                case "f": 
                    Console.WriteLine("\nYou selected a schedule [f]");
                    if (point.X >= 0 && point.Y >= 0)//+
                    {
                            if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                                Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'f'");
                            else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X >= 0 && point.Y <= 0)//+
                    {
                        if (Math.Abs(point.X - 0) + Math.Abs(point.Y - 0) <= 1)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'f'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y <= 0.5*point.X+1)//+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'f'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X <= 0 && point.Y <= 0)
                    {
                        if (point.Y >= -0.5 * point.X - 1)//+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'f'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    break;

                //triangle
                case "g":
                    Console.WriteLine("\nYou selected a schedule [g]");
                       if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))//+
                    {
                        if (point.Y <= 3 * point.X + 2)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'g'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y <= 0 && point.X <= 0))//+
                    {
                        if (point.Y >= -1)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'g'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))//+
                    {
                        if (point.Y <= -3 * point.X + 2) 
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'g'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    break;
                    
                //reversive flag
                case "h":
                    Console.WriteLine("\nYou selected a schedule [h]");
                    if ((point.Y <= 0 && point.X >= 0) || (point.X <= 0 && point.Y <= 0))
                    {
                        if (point.Y >= -2) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'h'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))
                    {
                        if ( point.X >= -1) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'h'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X >= 0 && point.Y >= 0) 
                    {
                        if (point.Y < point.X) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'h'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X) //-
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'h'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if ((point.Y <= 0 && point.X >= 0) || (point.Y >= 0 && point.X >= 0))
                    {
                        if (point.X <= 1) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'h'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    break;

                //Fiveangle
                case "i":
                    Console.WriteLine("\nYou selected a schedule [i]");
                    if ((point.Y >= 0 && point.X <= 0) || (point.Y <= 0 && point.X <= 0))//+
                    {
                        if (point.Y <= 2 * point.X + 3)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'i'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if ((point.Y <= 0 && point.X <= 0) || (point.Y <= 0 && point.X >= 0))
                    {
                        if (point.Y >= 0.3333333333333333333 * point.X - 0.3333333333333333333)//-
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'i'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.Y <= 0 && point.X >= 0) //-
                    {
                        if (point.Y <= 0)
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'i'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.X <= 0 && point.Y >= 0)
                    {
                        if (point.Y > -point.X) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'i'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    break;

                //4 lines + infinity 
                case "j":
                    Console.WriteLine("\nYou selected a schedule [j]");
                    if ((point.Y >= 0 && point.X >= 0) || (point.Y >= 0 && point.X <= 0))
                    {
                        if (point.Y >= 1) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'j'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.Y >= 0 && point.X >= 0)
                    {
                        if (point.Y < point.X) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'j'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    else if (point.Y >= 0 && point.X <= 0)
                    {
                        if (point.Y > -point.X) //+
                            Console.WriteLine($"The point [{point.X};{point.Y}] belongs to the figure 'j'");
                        else Console.WriteLine("BAD POINT.");
                    }
                    break;

                    default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nGraphics under this letter does not exist.");
                    break;
            }
        }
    }
}
