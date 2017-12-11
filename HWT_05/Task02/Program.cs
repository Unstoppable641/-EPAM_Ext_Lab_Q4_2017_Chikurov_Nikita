/* 
 Задание 2
Написать класс, описывающий треугольник со сторонами a, b, c, и
позволяющий осуществить расчёт его площади и периметра. Написать
программу, демонстрирующую использование данного треугольника
 */
namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (SysComponents.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter 3 sides of the triangle (separated by a Enter):");
                    Triangle.GetA = double.Parse(Console.ReadLine());
                    Triangle.GetB = double.Parse(Console.ReadLine());
                    Triangle.GetC = double.Parse(Console.ReadLine());
                    SysComponents.CheckZero();
                                       
                    Triangle.GetArea();
                    Triangle.GetLength();
                    SysComponents.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
