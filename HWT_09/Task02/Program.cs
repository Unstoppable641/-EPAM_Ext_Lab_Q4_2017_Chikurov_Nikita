/*
 Задание 2
 Напишите расширяющий метод, который определяет, является ли
строка положительным целым числом. Методы Parse и TryParse не
использовать.
 */
namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (EndProgram.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter String: ");
                    var str = Console.ReadLine();
                    Console.WriteLine("The string {0} is a number.", str.CheckPositiveOfNumber() ? " " : "Not");

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
