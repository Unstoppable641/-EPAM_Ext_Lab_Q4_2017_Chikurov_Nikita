/* 
 Задание 1
Написать класс Round, задающий круг с указанными координатами
центра, радиусом, а также свойствами, позволяющими узнать длину
описанной окружности и площадь круга. Обеспечить нахождение
объекта в заведомо корректном состоянии. Написать программу,
демонстрирующую использование данного круга.
 */
namespace Task01
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var round = new Round();
            while (SupportingComponents.Repeat)
            {
                try
                {
                    Console.Write("Enter the radius of the circle: ");
                    round.Radius = double.Parse(Console.ReadLine());

                    Console.Write("\nEnter the coordinates of the center of the circle: \nX: ");
                    round.X = double.Parse(Console.ReadLine());

                    Console.Write("\nY: ");
                    round.Y = double.Parse(Console.ReadLine());

                    Console.WriteLine($"\nArea of the Circle = {round.GetArea()}");
                    Console.WriteLine($"Length of the Circle = {round.GetLength()}");
                    Console.WriteLine(round.DisplayInfo());
                    SupportingComponents.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n\nERROR: {ex.Message}");
                }
            }
        }
    }
}
