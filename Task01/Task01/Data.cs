namespace Task01
{
    using System;

    public class Data
    {
        public static Point GetPoint()
        {
            var point = new Point();
            Console.WriteLine("Enter X:");
            point.X = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y:");
            point.Y = double.Parse(Console.ReadLine());

            return point;
        }

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
