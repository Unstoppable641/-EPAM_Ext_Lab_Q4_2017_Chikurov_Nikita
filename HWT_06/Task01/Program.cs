/*
Задание 1
На основе класса User(см.задание 3 из предыдущей темы), создать
класс Employee, описывающий сотрудника фирмы.В дополнение к
полям пользователя добавить поля «стаж работы» и «должность».
Обеспечить нахождение класса в заведомо корректном состоянии.
*/
namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var user = new User("America", "Make", "Great Again", new DateTime(1946, 06, 14));
                Console.WriteLine(user.Display());

                var emp = new Employee("Petr", "Poroshenko", "Alexeevich", new DateTime(1965, 09, 26), "OAO 'The Ukraine'", 10, "The President");
                Console.WriteLine(emp.Display());

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
