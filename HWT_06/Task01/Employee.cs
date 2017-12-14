/* 
 Наследование
Задание 1
На основе класса User (см. задание 3 из предыдущей темы), создать
класс Employee, описывающий сотрудника фирмы. В дополнение к
полям пользователя добавить поля «стаж работы» и «должность».
Обеспечить нахождение класса в заведомо корректном состоянии.
 */
namespace Task01
{
    using System;

    public class Employee : User
    {
        private DateTime workEx;

        public Employee(string firstName, string lastName, string patronymic, DateTime birthday, string comp, int wexp, string pos)
    : base(firstName, lastName, patronymic, birthday)
        {
            this.Position = pos;
            this.WorkExperience = wexp;
            this.Company = comp;
        }

        public string Company { get; set; }

        public int WorkExperience { get; set; }

        public string Position { get; set; }

        public DateTime WorkEx
        {
            get
            {
                return this.workEx;
            }

            set
            {
                this.workEx = value;
                this.WorkExperience = this.GetЕxperience();
            }
        }

        public int GetЕxperience()
        {
            var today = DateTime.Today;

            if (today.Month < this.WorkEx.Month || (today.Month == this.WorkEx.Month && today.Day < this.WorkEx.Day))
            {
                this.WorkExperience = today.Year - this.WorkEx.Year - 1;
            }
            else
            {
                this.WorkExperience = today.Year - this.WorkEx.Year;
            }

            return this.WorkExperience;
        }

        public new string Display()
        {
            return string.Format($"LastName: {LastName} \nFirstName: {FirstName} \nPatrinymic: {Patronymic} \nBirth: {birthday} \nAge: {Age} \nWork Experience: {WorkExperience} \nPosition: {Position}\n");
        }
    }
}
