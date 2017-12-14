/* 
 не смог полностью вовремя сделать это задание,
 готов к оценке 0 баллов.
 */
namespace Task04
{
    using System;

    public class MyString
    {
        private char[] str;
        public char[] StrVal { get; set; }
        public MyString(char[] s)
        {
            StrVal = s;
        }
        public static MyString operator +(MyString str1, MyString str2)
        {
            char[] s1 = str1.StrVal;
            char[] s2 = str2.StrVal;
            char[] s = new char[s1.Length + s2.Length];

            for (var i = 0; i < s1.Length; i++)
            {
                s[i] = s1[i];
            }

            for (var i = 0; i < s2.Length; i++)
            {
                s[s1.Length + i] = s2[i];
            }

            var newstr = new MyString(s);
            return newstr;
        }

        public void ToUpper(MyString str1)
        {
            char[] s1 = str1.StrVal;
            char[] s = new char[s1.Length];
            foreach (var ch in s)
            {
                Console.WriteLine($"{ch} -> {char.ToUpper(ch)}");
            }
        }

        public int Length()
        {
            return str.Length;
        }
        public void Write()
        {
            foreach (var i in str)
            {
                Console.Write($"{Convert.ToChar(i)}");
            }
        }
        public void Insert(int pos, char[] s)
        {
            char[] newstr = new char[str.Length + s.Length];
            var j = 0;
            for (var i = 0; i < newstr.Length; i++)
            {
                if (i < pos)
                {
                    newstr[i] = str[j++];
                }
                else
                if (i == pos)
                {
                    foreach (var k in s)
                    {
                        newstr[i++] = s[k];
                    }
                }
                else
                {
                    newstr[i - 1] = str[j++];
                }
            }
            var n = new MyString(newstr);
            StrVal = n.StrVal;
        }
    }
}
