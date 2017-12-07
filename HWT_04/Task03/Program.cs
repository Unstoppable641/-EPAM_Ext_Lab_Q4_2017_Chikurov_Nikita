/* 
Задание 3
Проведите сравнительный анализ скорости работы классов String и
StringBuilder для операции сложения строк
 */
 namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class Program
    {
        public static void Main(string[] args)
        {
            while (Data.Repeat)
            {
                try
                {
                    Console.WriteLine("Enter number of steps [n]");
                    var n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        throw new ArgumentException("[n] must be greater than zero ");
                    }

                    Data.ElapsedWithoutSB(n);
                    Data.ElapsedWithSB(n);
                    Data.WhileExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
