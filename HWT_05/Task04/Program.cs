/* 
 Задание 4
Написать свой собственный класс MyString, описывающий строку как
массив символов. Перегрузить для этого класса типовые операции.
 */
namespace Task04
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter string 1: ");
            char[] str1 = Console.ReadLine().ToCharArray();
            Console.Write("Enter string 2: ");
            char[] str2 = Console.ReadLine().ToCharArray();

            var mystr1 = new MyString(str1);
            var mystr2 = new MyString(str2);

            var mystr3 = mystr1 + mystr2;

            Console.Write("\noperator +: ");
            mystr3.Write();

           // mystr1.ToUpper(mystr1);

            mystr1.Insert(3, mystr2.StrVal);
            Console.Write("\nInsert: ");
            mystr1.Write();
        }
    }
}
