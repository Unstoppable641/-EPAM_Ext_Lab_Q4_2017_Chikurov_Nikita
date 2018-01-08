/*
 Задание 1
Написать программу, выполняющую сортировку массива строк по
возрастанию длины. Если строки состоят из равного числа символов,
их следует отсортировать по алфавиту. Реализовать метод сравнения
строк отдельным методом, передаваемым в сортировку через делегат.
 */
namespace Task001
{
    using System;

    public class Program
    {
        public delegate void Comparing(ref string first, ref string second);

        public static void Main(string[] args)
        {
            while (EndProgram.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter words with a space to compose a string array");
                    var input = Console.ReadLine();
                    if (input != null)
                    {
                        var strings = input.Split(' ');
                        var del = new Methods.Comparing(Methods.Compare);

                        Methods.Sort(strings, del);
                        foreach (var word in strings)
                        {
                            Console.Write(word + " ");
                        }
                    }

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
