/* 
 Задание 3
Написать класс User, описывающий человека (Фамилия, Имя,
Отчество, Дата рождения, Возраст). Написать программу,
демонстрирующую использование этого класса.
 */
namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var user = new User();
            while (EndProgram.Repeat)
            {
                try
                {
                    Console.Write("Enter Last Name: ");
                    user.LastName = Console.ReadLine();

                    Console.Write("\nEnter First Name: ");
                    user.FirstName = Console.ReadLine();

                    Console.Write("\nEnter Patronymic: ");
                    user.Patronymic = Console.ReadLine();

                    Console.WriteLine($"\nHello! {user.LastName} {user.FirstName}");

                    Console.Write("\nEnter the date of birth through a space, Example - (15 03 1990): ");
                    user.Birthday = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine($"Your age: {user.Age}");

                    EndProgram.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
