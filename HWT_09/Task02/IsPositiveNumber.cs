namespace Task02
{
    using System;
    using System.Linq;

    public static class IsPositiveNumber
    {
        public static bool CheckPositiveOfNumber(this string param)
        {
            return param.All(char.IsDigit);
        }
    }
}
