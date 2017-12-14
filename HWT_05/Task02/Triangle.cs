namespace Task02
{
    using System;

    public static class Triangle
    {
        /// <summary>
        /// стороны треугольников.
        /// </summary>
        private static double a;
        private static double b;
        private static double c;

        public static double GetA
        {
            get
            {
                return a;
            }

            set
            {
                if (value > 0)
                {
                    a = value;
                }
            }
        }

        public static double GetB
        {
            get
            {
                return b;
            }

            set
            {
                if (value > 0)
                {
                    b = value;
                }
            }
        }

        public static double GetC
        {
            get
            {
                return c;
            }

            set
            {
                if (value > 0)
                {
                    c = value;
                }
            }
        }

        public static void GetArea()
        {
            //// Формула Герона.
            //// Источник:
            //// http://www.webmath.ru/poleznoe/formules16.php 
            var p = (GetA + GetB + GetC) / 2;
            var area = Math.Sqrt(p * (p - a) * (p - GetB) * (p - GetC));
            Console.WriteLine($"The area of the triangle = {area}");
        }

        public static void GetLength()
        {
            var length = GetA + GetB + GetC;
            Console.WriteLine($"The perimeter of the triangle = {length}");
        }
    }
}
