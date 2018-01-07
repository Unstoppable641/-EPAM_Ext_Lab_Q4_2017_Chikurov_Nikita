namespace Task01
{
    using System;

    public class Office
    {
        private GreetingMessage greeting;
        private PartingMessage parting;

        public void InitGreeting(Person active, Person passive)
        {
            this.greeting += active.Greeting;
            passive.OnCame += this.greeting;
        }

        public void InitBye(params Person[] persons)
        {
            foreach (var person in persons)
            {
                this.parting += person.Parting;
            }
        }

        public void AddEveningBye(Person personOut)
        {
            if (this.parting != null)
            {
                personOut.OnLeave += this.parting;
            }
        }

        public void RemoveBye(Person person)
        {
            if (this.parting != null)
            {
                this.parting -= person.Parting;
            }
        }
    }
}
