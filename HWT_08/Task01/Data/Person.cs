namespace Task01
{
    using System;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public event GreetingMessage OnCame;

        public event PartingMessage OnLeave;

        private string Name { get; }

        public void Enter()
        {
            Console.WriteLine($"\n[{this.Name} пришел на работу.]");
            this.OnCame?.Invoke(this, new Time());
        }

        public void Exit()
        {
            Console.WriteLine($"\n[{this.Name} ушел домой.]");
            this.OnLeave?.Invoke(this);
        }

        public void Greeting(Person person, Time time)
        {
            if (Time.Timing.Hour < 12)
            {
                Console.WriteLine($"\'{person.Name}, Доброе утро\', - сказал {this.Name}.");
                return;
            }

            if (Time.Timing.Hour >= 17)
            {
                Console.WriteLine($"\'{person.Name}, Добрый вечер\', - сказал {this.Name}.");
                return;
            }

            if (Time.Timing.Hour >= 12) return;
            Console.WriteLine($"\'{person.Name}, Добрый день\', - сказал {this.Name}.");
            return;
        }

        public void Parting(Person person)
        {
            Console.WriteLine($"\'{person.Name}, До свидания\', - сказал {this.Name}");
        }
    }
}
