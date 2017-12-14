/* 
 Задание 2
Создать класс Ring (кольцо), описываемое координатами центра,
внешним и внутренним радиусами, а также свойствами, позволяющими
узнать площадь кольца и суммарную длину внешней и внутренней
границ кольца. Обеспечить нахождение класса в заведомо корректном
состоянии.
 */
namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var round = new Round(1, 1, 4);
                var ring = new Ring();

                while (EndProgram.Repeat)
                {
                    Console.WriteLine($"{round.Display()}\n");

                    Console.Write("Enter the outer radius of the ring: ");
                    ring.OutteR = int.Parse(Console.ReadLine());

                    Console.Write("Enter the inner radius of the ring: ");
                    ring.InneR = int.Parse(Console.ReadLine());

                    Console.Write("Enter the coordinates of the center of the ring: \nX: ");
                    ring.X = int.Parse(Console.ReadLine());

                    Console.Write("Y: ");
                    ring.Y = int.Parse(Console.ReadLine());

                    Console.WriteLine(ring.Display());

                    EndProgram.WhileExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
