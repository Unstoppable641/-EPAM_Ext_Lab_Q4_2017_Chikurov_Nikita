/*
 Задание 2
Написать программу, описывающую небольшой офис, в котором
работают сотрудники – объекты класса Person, обладающие полем имя
(Name). Каждый из сотрудников содержит пару методов: приветствие
сотрудника, пришедшего на работу (принимает в качестве аргументов
объект сотрудника и время его прихода) и прощание с ним (принимает
только объект сотрудника). В зависимости от времени суток,
приветствие может быть различным: до 12 часов – «Доброе утро», с 12
до 17 – «Добрый день», начиная с 17 часов – «Добрый вечер». Каждый
раз при входе очередного сотрудника в офис, все пришедшие ранее его
приветствуют. При уходе сотрудника домой с ним также прощаются все
присутствующие. Вызов процедуры приветствия/прощания
производить через групповые делегаты. Факт прихода и ухода
сотрудника отслеживается через генерируемые им события. Событие
прихода описывается делегатом, передающим в числе параметров
наследника EventArgs, явно содержащего поле с временем прихода.
Продемонстрировать работу офиса при последовательном приходе и
уходе сотрудников. */
namespace Task01
{
    using System;

    public delegate void GreetingMessage(Person person, Time time);

    public delegate void PartingMessage(Person person);

    public class Program
    {
        public static void Main(string[] args)
        {
            var ivan = new Person("Иван");
            var petr = new Person("Петр");
            var alexander = new Person("Александр");

            var office = new Office();
            ivan.Enter();

            office.InitGreeting(ivan, petr);
            petr.Enter();

            office.InitGreeting(petr, alexander);
            alexander.Enter();

            office.InitBye(ivan, petr);
            office.AddEveningBye(alexander);
            alexander.Exit();

            office.RemoveBye(petr);
            office.AddEveningBye(petr);
            petr.Exit();

            ivan.Exit();

            Console.ReadLine();
        }
    }
}
