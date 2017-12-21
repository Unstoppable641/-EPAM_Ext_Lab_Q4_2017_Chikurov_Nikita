/*
 Задание 1
В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета
по кругу вычёркивается каждый второй человек, пока не останется
один. Составить программу, моделирующую процесс.
*/
namespace Task01
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (EndProg.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter the number of people: ");
                    var countPeople = DeletingEverySecondN.ReadNumber();
                    List<int> list = new List<int>(countPeople);
                    for (var i = 1; i < countPeople + 1; i++)
                    {
                        list.Add(i);
                    }

                    DeletingEverySecondN.PrintList(list);

                    while (list.Count > DeletingEverySecondN.WhileListHaveNumbers)
                    {
                        for (var i = 0; i < list.Count; i++)
                        {
                            if (DeletingEverySecondN.Delete)
                            {
                                list.RemoveAt(i--);
                            }

                            DeletingEverySecondN.Delete = !DeletingEverySecondN.Delete;
                        }

                        DeletingEverySecondN.PrintList(list);
                    }

                    EndProg.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
