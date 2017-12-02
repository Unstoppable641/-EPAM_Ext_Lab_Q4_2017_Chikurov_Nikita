/* 
 * Задание 2
Написать программу, которая запрашивает с клавиатуры число N и
выводит на экран следующее «изображение», состоящее из N строк.
 */
 namespace Task02
{
    using System;

    public class Program
    {
       public static void Main(string[] args)
        {
           var repeat = true;
           while (repeat)
           {
               try
               {
                   Console.Write("Enter the number [n] = ");
                   var n = int.Parse(Console.ReadLine());
                   Data.ThrowEx(n);

                   Data.PrintStairs(n);

                   Console.WriteLine("\nTRY AGAIN ? [Y/N]");
                   var ki = Console.ReadKey(true);
                   if (ki.Key != ConsoleKey.Y)
                   {
                       repeat = false;
                       Console.ReadKey();
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"ERROR: {ex.Message}");
               }
           }
        }
    }
}
