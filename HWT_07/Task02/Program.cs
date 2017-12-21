/*
 Задание 2
Задан английский текст. Выделить отдельные слова и для каждого
посчитать частоту встречаемости. Слова, отличающиеся регистром,
считать одинаковыми. В качестве разделителей считать пробел и точку
 */
namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (EndProg.Repeat)
            {
                try
                {
                    var sumWords = 0;
                    Console.Write("Enter the text: ");
                    var sentence = Console.ReadLine();
                    sentence += " ";
                    var word = string.Empty;
                    List<FieldsForWords> allWords = new List<FieldsForWords>();

                    foreach (var item in sentence)
                    {
                        if ((item != ' ') && (item != '.'))
                        {
                            word += item;
                        }
                        else
                        {
                            if (word != string.Empty)
                            {
                                sumWords++;
                                word = word.ToLower();
                                var flag = false;
                                foreach (var w in allWords.Where(w => w.Word == word))
                                {
                                    w.IncAmout();
                                    flag = true;
                                    break;
                                }

                                if (!flag)
                                {
                                    allWords.Add(new FieldsForWords.WordAndAmound(word));
                                }

                                word = string.Empty;
                            }
                        }
                    }

                    Console.WriteLine($"Total of words: {allWords.Count}\n");
                    foreach (var item in allWords)
                    {
                        Console.WriteLine($"The word {item.Word} met {item.Amout} time(s)");
                    }

                    EndProg.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}