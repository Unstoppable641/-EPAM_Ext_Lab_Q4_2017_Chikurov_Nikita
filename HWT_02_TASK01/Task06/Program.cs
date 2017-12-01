/* 
 Задание 6
Для выделения текстовой надписи можно использовать выделение
жирным, курсивом и подчёркиванием. Предложите способ хранения
информации о выделении надписи и напишите программу, которая
позволяет назначать и удалять текстовой надписи выделение:
 */
namespace Task06
{
    using System;
 
    public class Program
    {
        public static void Main(string[] args)//todo pn нет разделения логик UI и бизнеса + не выполнено требование задания (убирание стиля при повторном введении)
        {
            string[] str = { "None", "Bold", "Italic", "Underline" };
            int[] num = new int[4];
            string result = str[num[0]];
            int choice = 4;

            while (choice != 0)
            {
                try
                {
                    for (int i = 0; i < num.Length; i++)
                    {
                        if (num[i] != 0)
                        {
                            if (result == str[num[0]])
                            {
                                result = string.Empty;
                            }

                            {
                                ////r1-вывод прошлого парам.
                                ////r2-Добавляет символы после парам.
                                var r1 = str[num[i]];
                                var r2 = i < num.Length - 1 && num[i + 1] != 0 ? ", " : " ";
                                result += string.Format($"{r1}{r2}");
                            }
                        }
                    }

                    Console.Write($"Parameters: {result}\nchoose:\n");
                    Console.WriteLine("\t0: Exit");

                    for (int i = 1; i < 4; i++)
                    {
                        Console.WriteLine($"\t{i}: {str[i]}");
                    }

                    choice = int.Parse(Console.ReadLine());
                    if (choice < 0 || choice > 3)
                    {
                        throw new System.ArgumentException("This is not in the list. Please try again");
                    }

                    num[choice] = (num[choice] == 0) ? choice : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
