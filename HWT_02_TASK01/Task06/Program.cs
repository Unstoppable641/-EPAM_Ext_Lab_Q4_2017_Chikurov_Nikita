/* 
 Задание 6
Для выделения текстовой надписи можно использовать выделение
жирным, курсивом и подчёркиванием. Предложите способ хранения
информации о выделении надписи и напишите программу, которая
позволяет назначать и удалять текстовой надписи выделение:
 */
namespace Task06
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Data.Bold = Data.Italic = Data.Underline = false;
            while (Data.UsingStyles)
            {
                Data.Print();
                Data.SelectedStyle();
            }
        }
    }
}