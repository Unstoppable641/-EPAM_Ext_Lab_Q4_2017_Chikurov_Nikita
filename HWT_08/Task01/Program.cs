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
