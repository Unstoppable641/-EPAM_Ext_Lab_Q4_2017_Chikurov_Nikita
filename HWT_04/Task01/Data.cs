namespace Task01
{
    using System;
    using System.Linq;

    public static class Data
    {
        public static bool Repeat = true;
        private const int IndBegin = 0;
        private const int IndLast = 0;
        private const int WordLength = IndLast - IndBegin;

        public static void MiddleString()
        {
            var allWordLength = 0;

            Console.WriteLine("Enter the string:\n");
            var str = Console.ReadLine();
            var arr = str.Split(new char[] { ' ', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);//todo pn костыль. Используй Char.IsSeparator
            for (var i = 0; i < arr.Length; i++)
            {
                allWordLength += arr.Sum(s => s.Length);
                allWordLength = allWordLength + WordLength;
            }

            var numberOfCharacters = allWordLength / arr.Length;//todo pn неправильная логика работы. Тебе нужно "среднюю длину слова во введенной текстовой строке"
			Console.WriteLine($"\nNumber of characters in string [{str}] = {numberOfCharacters}");
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
