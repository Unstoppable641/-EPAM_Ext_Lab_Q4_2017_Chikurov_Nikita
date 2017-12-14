namespace Task01
{
    using System;
    using System.Data;

    public class User
    {
        public DateTime birthday;

        public User(string firstName, string lastName, string patronymic, DateTime birthday)
        {
            this.Birthday = birthday;
            this.Patronymic = patronymic;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public int Age => DateTime.Now.Year - this.Birthday.Year;
        
        private DateTime Birthday
        {
            get
            {
                return this.birthday;
            }

            set
            {
                this.birthday = value;

                if (this.birthday.Year == DateTime.Now.Year || this.birthday.Year > DateTime.Now.Year - 3)
                {
                    throw new Exception("Invalid data");
                }
            }
        }

        public string Display()
        {
           return string.Format($"LastName: {LastName} \nFirstName: {FirstName} \nPatrinymic: {Patronymic} \nBirth: {Birthday} \nAge: {Age}\n");
        }
    }
}
