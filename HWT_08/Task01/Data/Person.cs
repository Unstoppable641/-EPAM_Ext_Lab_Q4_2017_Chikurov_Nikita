﻿namespace Task01
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
            Console.WriteLine($"\n[{this.Name} пришел на работу.]");//todo pn хардкод
            this.OnCame?.Invoke(this, new Time());
        }

        public void Exit()
        {
            Console.WriteLine($"\n[{this.Name} ушел домой.]");//todo pn хардкод
			this.OnLeave?.Invoke(this);
        }

        public void Greeting(Person person, Time time)
        {
            if (Time.Timing.Hour < 12)
            {
                Console.WriteLine($"\'{person.Name}, Доброе утро\', - сказал {this.Name}.");//todo pn хардкод
				return;
            }

            if (Time.Timing.Hour >= 17)
            {
                Console.WriteLine($"\'{person.Name}, Добрый вечер\', - сказал {this.Name}.");//todo pn хардкод
				return;
            }

            if (Time.Timing.Hour >= 12) return;
            Console.WriteLine($"\'{person.Name}, Добрый день\', - сказал {this.Name}.");//todo pn хардкод
			return;
        }

        public void Parting(Person person)
        {
            Console.WriteLine($"\'{person.Name}, До свидания\', - сказал {this.Name}.");//todo pn хардкод
		}
    }
}
