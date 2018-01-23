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
            while (EndProg.Repeat)//todo pn в отдельную сборку чтобы не повторять код в разных проектах
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

                    while (list.Count > DeletingEverySecondN.WhileListHaveNumbers) //todo pn у тебя бизнес логика не вынесена в отдельный класс и не отделена от логики представления
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

                    EndProg.WhileExit();//todo pn в отдельную сборку чтобы не повторять код в разных проектах
				}
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
