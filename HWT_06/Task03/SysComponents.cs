namespace Task03
{
    using System;

    public static class SysComponents
    {
        public static bool Repeat = true;

        public static void WhileExit()
        {
            Console.WriteLine("\nTRY AGAIN ? [Y/N]");
            var ki = Console.ReadKey(true);
            if (ki.Key != ConsoleKey.Y)
            {
                Repeat = false;
                Console.ReadKey();
            }
        }
    }
}
