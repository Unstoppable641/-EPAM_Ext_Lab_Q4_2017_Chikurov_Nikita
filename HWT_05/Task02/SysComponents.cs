namespace Task02
{
    using System;

    public static class SysComponents
    {
        public static bool Repeat = true;

        public static void CheckZero()
        {
            //// проверка на 0.
            if (Triangle.GetA <= 0 || Triangle.GetB <= 0 || Triangle.GetC <= 0)
            {
                throw new ArgumentException();
            }
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
