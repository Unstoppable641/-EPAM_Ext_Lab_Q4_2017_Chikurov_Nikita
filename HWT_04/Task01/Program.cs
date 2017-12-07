/* 
 Задание 1
Написать программу, которая определяет среднюю длину слова во
введенной текстовой строке. Учесть, что символы пунктуации на длину
слов влиять не должны. Регулярные выражения не использовать. И не
пытайтесь прописать все ручками. Используйте стандартные методы
класса String
 */
namespace Task01
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            while (Data.Repeat)
            {
                Data.MiddleString();
                Data.WhileExit();
            }
        }
    }
}
