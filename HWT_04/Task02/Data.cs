namespace Task02
{
    using System;
    using System.Linq;

    public static class Data
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

        public static void DoubleSymbols()
        {
            var firstString = string.Empty;
            var secondString = string.Empty;
            var finalString = string.Empty;
            Console.WriteLine("Enter the First line:\n ");
            firstString = Console.ReadLine();
            Console.WriteLine("Enter the Second line containing the characters of the First line:\n ");
            secondString = Console.ReadLine();
            if (firstString != null)
            {
                foreach (var ch in firstString)
                {
                    if (secondString != null && !secondString.Contains(ch))
                    {
                        finalString += ch;
                    }
                    else
                    {
                        finalString += ch;
                        finalString += ch;
                    }
                }
            }

            Console.WriteLine($"Result = {finalString}");
        }
    }
}
/*
 * 
------ StyleCop 5.0 (build 5.0.6419.0) started ------

Pass 1:   Task01 - \Data.cs
Pass 1:   Task01 - \Program.cs
Pass 1:   Task01 - \Properties\AssemblyInfo.cs
Pass 1:   Task02 - \Data.cs
Pass 1:   Task02 - \Program.cs
Pass 1:   Task02 - \Properties\AssemblyInfo.cs
Pass 1:   Task03 - \Data.cs
Pass 1:   Task03 - \Program.cs
Pass 1:   Task03 - \Properties\AssemblyInfo.cs

------ StyleCop completed ------

========== Violation Count: 3 ==========
 */
