namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class Data
    {
        public static bool Repeat = true;

        public static void ElapsedWithoutSB(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            string str = string.Empty;

            for (int i = 0; i < n; i++)
            {
                str += "*";//todo pn хардкод
            }

            sw.Stop();
            Console.WriteLine("Time Spent w/o StringBuilder:\n" + sw.Elapsed);
        }

        public static void ElapsedWithSB(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append("*");//todo pn хардкод
			}

            sw.Stop();
            Console.WriteLine("Time Spent w/ StringBuilder:\n" + sw.Elapsed);
        }

        public static void WhileExit()
        {
            Console.WriteLine("\nTRY AGAIN ? [Y/N]");
            var ki = Console.ReadKey(true);
            if (ki.Key == ConsoleKey.Y)
            {
                return;
            }

            Repeat = false;
            Console.ReadKey();
        }
    }
}
