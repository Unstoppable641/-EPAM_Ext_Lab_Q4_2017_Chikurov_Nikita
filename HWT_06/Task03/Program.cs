/*
 Полиморфизм
Задание 3
Напишите заготовку для векторного графического редактора. Полная
версия редактора должна позволять создавать и выводить на экран
такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо.
Заготовка, для упрощения, должна представлять собой консольное
приложение с функционалом:
1. Создать фигуру выбранного типа по произвольным координатам.
2. Вывести фигуры на экран (для каждой фигуры вывести на консоль
её тип и значения параметров).
 */
namespace Task03
{
    using System;
    using Task03.Figures;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (SysComponents.Repeat)
            {
                try
                {
                    Console.WriteLine("Select a shape: \n 1: Line \n 2: Circle \n 3: Rectangle \n 4: Circle \n 5: Ring");
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var line = new Line(2, 5, 1, 4);
                            Console.WriteLine(line.Display());
                            break;

                        case "2":
                            var circle = new Circle(0, 0, 4);
                            Console.WriteLine(circle.Display());
                            break;

                        case "3":
                            var rectangle = new Rectangle(0, 0, 1, 2);
                            Console.WriteLine(rectangle.Display());
                            break;

                        case "4":
                            var round = new Round(0, 0, 5);
                            Console.WriteLine(round.Display());
                            break;

                        case "5":
                            var ring = new Ring(0, 0, 3, 1);
                            Console.WriteLine(ring.Display());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }

                SysComponents.WhileExit();
            }
        }
    }
}
