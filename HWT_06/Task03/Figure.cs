namespace Task03
{
    using System;

    public abstract class Figure
    {
       public Figure()
        {
            var rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            this.X = rand.Next(20) - 10;
            this.Y = rand.Next(20) - 10;
        }

        public Figure(int centerX, int centerY)
        {
            this.X = centerX;
            this.Y = centerY;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public double Length()
        {
            return 0;
        }

        public string Display()
        {
            return "The figure is not selected.";
        }

        public double Area()
        {
            return 0;
        }
    }
}
