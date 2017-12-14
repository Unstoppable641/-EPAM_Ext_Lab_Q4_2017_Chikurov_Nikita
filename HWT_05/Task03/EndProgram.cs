namespace Task03
{
    using System;

    public class EndProgram
    {
        public static bool Repeat = true;

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
