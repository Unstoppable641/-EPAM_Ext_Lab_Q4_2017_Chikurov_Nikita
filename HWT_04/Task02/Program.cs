/* 
 Задание 2
Написать программу, которая удваивает в первой введенной строки все
символы, принадлежащие второй введенной строке.
 */
namespace Task02
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            while (Data.Repeat)
            {
                Data.DoubleSymbols();
                Data.WhileExit();
            }
        }
    }
}
