namespace Task01
{
    using System;

    public class Data
    {
        public static void SetMessage(bool f, string s, double x, double y)
        {
            if (f)
            {
                Console.WriteLine($"The point [{x};{y}] belongs to the figure {s}");
            }
            else
            {
                Console.WriteLine("BAD POINT.");
            }
        }

        public class Point
        {
            public double X { get; set; }

            public double Y { get; set; }
        }
    }
}
