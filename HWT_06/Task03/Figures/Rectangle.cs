namespace Task03
{
    using System;

    public class Rectangle : Figure
    {
        /// <param name="x">Coordinate X of the center of the figure </param>
        /// <param name="y">Coordinate At the center of the figure </param>
        /// <param name="a">Side A </param>
        /// <param name="b">Side B </param>
        public Rectangle()
        {
        }

        public Rectangle(int x, int y, int a, int b)
                        : base(x, y)
        {
            this.SideA = a;
            this.SideB = b;
        }

        public int SideA { get; set; }

        public int SideB { get; set; }

        public new double Length()
        {
            return 2 * (this.SideA + this.SideB);
        }

        public new double Area()
        {
            return this.SideA * this.SideB;
        }

        public new string Display()
        {
            return
                $"RECTANGEL. Center: ({X}; {Y}), Side A: {SideA}, Side B: {SideB}, Perimeter: {Length(): 0, ##}, Area: {Area(): 0, ##}";
        }
    }
}
