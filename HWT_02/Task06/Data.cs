namespace Task06
{
    using System;

    public class Data
    {
        public static string Style = "None";
        public static bool Bold;
        public static bool Italic;
        public static bool Underline;
        public static int N;
        public static bool UsingStyles = true;

        public static void Print()
        {
            Console.WriteLine($"Parameters:  {Style}\nchoose:\n\t 1:  bold\n\t 2:  italic\n\t 3:  underline\n\t 0:  Exit");
        }

        public static void SelectedStyle()
        {
            int.TryParse(Console.ReadLine(), out N);
            switch (N)
            {
                case 1:
                    StyleCheck("Bold", ref Bold);
                    break;
                case 2:
                    StyleCheck("Italic", ref Italic);
                    break;
                case 3:
                    StyleCheck("Underline", ref Underline);
                    break;
                case 0:
                    UsingStyles = false;
                    break;
            }
        }

        public static void StyleCheck(string str, ref bool check)
        {
            string str2 = ", " + str + ",";
            string str3 = ", " + str;
            string str4 = str + ", ";
            string str5 = string.Empty;
            var none = Style == "None";
            var empty = Style == str5;

            if (check)
            {
                if (Style.Contains(str2))
                {
                    Style = Style.Replace(str2, str5);
                }
                else if (Style.Contains(str3))
                {
                    Style = Style.Replace(str3, str5);
                }
                else if (Style.Contains(str4))
                {
                    Style = Style.Replace(str4, str5);
                }
                else if (Style.Contains(str))
                {
                    Style = Style.Replace(str, str5);
                }

                check = false;

                if ((!Italic) && (!Underline) && (!Bold))
                {
                    Style = "None";
                }
            }
            else
            {
                check = true;

                if (none || empty)
                {
                    Style = str;
                }
                else
                {
                    Style = Style + str3;
                }
            }
        }
    }
}
