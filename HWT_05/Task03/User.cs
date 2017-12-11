namespace Task03
{
    using System;

    public class User
    {
        private DateTime birthday;

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday
        {
            private get
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

        public int Age => DateTime.Now.Year - this.Birthday.Year;
    }
}
